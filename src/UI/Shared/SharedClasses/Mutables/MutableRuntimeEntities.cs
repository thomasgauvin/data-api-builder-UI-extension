// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Azure.DataApiBuilder.Config.ObjectModel;
using Humanizer;

namespace UI.Shared.SharedClasses.Mutables
{
    /// <summary>
    /// Represents the collection of <see cref="MutableEntity"/> available from the RuntimeConfig.
    /// </summary>
    [JsonConverter(typeof(RuntimeEntitiesConverter))]
    public class MutableRuntimeEntities : IEnumerable<KeyValuePair<string, MutableEntity>>
    {
        /// <summary>
        /// The collection of <see cref="MutableEntity"/> available from the RuntimeConfig.
        /// </summary>
        public IDictionary<string, MutableEntity> Entities { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="RuntimeEntities"/> class using a collection of entities.
        /// 
        /// The constructor will apply default values for the entities for GraphQL and REST.
        /// </summary>
        /// <param name="entities">The collection of entities to map to RuntimeEntities.</param>
        public MutableRuntimeEntities(IReadOnlyDictionary<string, Entity> entities)
        {
            Dictionary<string, MutableEntity> parsedEntities = new();

            foreach ((string key, Entity entity) in entities)
            {
                MutableEntity processedEntity = ProcessGraphQLDefaults(key, new(entity));
                processedEntity = ProcessRestDefaults(processedEntity);

                parsedEntities.Add(key, processedEntity);
            }

            Entities = parsedEntities;
        }

        public MutableRuntimeEntities(MutableRuntimeEntities runtimeEntities)
        {
            Dictionary<string, MutableEntity> parsedEntities = new();

            foreach ((string key, MutableEntity entity) in runtimeEntities)
            {
                MutableEntity processedEntity = ProcessGraphQLDefaults(key, entity);
                processedEntity = ProcessRestDefaults(processedEntity);

                parsedEntities.Add(key, processedEntity);
            }

            Entities = parsedEntities;
        }   

        public IEnumerator<KeyValuePair<string, MutableEntity>> GetEnumerator()
        {
            return Entities.GetEnumerator();
        }

        public bool TryGetValue(string key, [NotNullWhen(true)] out MutableEntity? entity)
        {
            return Entities.TryGetValue(key, out entity);
        }

        public bool ContainsKey(string key)
        {
            return Entities.ContainsKey(key);
        }

        public MutableEntity this[string key] => Entities[key];

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Process the GraphQL defaults for the entity.
        /// </summary>
        /// <param name="entityName">The name of the entity.</param>
        /// <param name="entity">The previously parsed <c>Entity</c> object.</param>
        /// <returns>A processed <c>MutableEntity</c> with default rules applied.</returns>
        private static MutableEntity ProcessGraphQLDefaults(string entityName, MutableEntity entity)
        {

            MutableEntity nameCorrectedEntity = entity;

            // If no GraphQL node was provided in the config, set it with the default state
            if (nameCorrectedEntity.GraphQL is null)
            {
                nameCorrectedEntity.GraphQL = new(Singular: entityName, Plural: string.Empty);
            }

            // If no Singular version of the entity name was provided, use the MutableEntity Name from the config
            if (string.IsNullOrEmpty(nameCorrectedEntity.GraphQL.Singular))
            {
                nameCorrectedEntity.GraphQL.Singular = entityName;
            }

            // If no Plural version for the entity name was provided, pluralise the singular version.
            if (string.IsNullOrEmpty(nameCorrectedEntity.GraphQL.Plural))
            {
                nameCorrectedEntity.GraphQL.Plural = nameCorrectedEntity.GraphQL.Singular.Pluralize();
            }

            // If this is a Stored Procedure with no provided GraphQL operation, set it to Mutation as the default
            if (nameCorrectedEntity.GraphQL.Operation is null && nameCorrectedEntity.Source.Type is EntitySourceType.StoredProcedure)
            {
                nameCorrectedEntity.GraphQL.Operation = GraphQLOperation.Mutation;
            }

            return nameCorrectedEntity;
        }

        private static MutableEntity ProcessRestDefaults(MutableEntity nameCorrectedEntity)
        {
            // If no Rest node was provided in the config, set it with the default state of enabled for all verbs
            if (nameCorrectedEntity.Rest is null)
            {
                if(nameCorrectedEntity.Source.Type is EntitySourceType.StoredProcedure)
                {
                    nameCorrectedEntity.Rest = new MutableEntityRestOptions(MutableEntityRestOptions.DEFAULT_HTTP_VERBS_ENABLED_FOR_SP);
                }
                else
                {
                    nameCorrectedEntity.Rest = new MutableEntityRestOptions(Enabled: true);
                }
            }
            else if (nameCorrectedEntity.Source.Type is EntitySourceType.StoredProcedure && (nameCorrectedEntity.Rest.Methods is null || nameCorrectedEntity.Rest.Methods.Length == 0))
            {
                // REST Method field is relevant only for stored procedures. For an entity backed by a table/view, all HTTP verbs are enabled by design
                // unless configured otherwise through the config file. An entity backed by a stored procedure also supports all HTTP verbs but only POST is 
                // enabled by default unless otherwise specified.
                // When the Methods property is configured in the config file, the parser correctly parses and populates the methods configured.
                // However, when absent in the config file, REST methods that are enabled by default needs to be populated.
                nameCorrectedEntity.Rest = new MutableEntityRestOptions(Methods: MutableEntityRestOptions.DEFAULT_HTTP_VERBS_ENABLED_FOR_SP, Path: nameCorrectedEntity.Rest.Path, Enabled: nameCorrectedEntity.Rest.Enabled);
            }

            return nameCorrectedEntity;
        }
    }
}

