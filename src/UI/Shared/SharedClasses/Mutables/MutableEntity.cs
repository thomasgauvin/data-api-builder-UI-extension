using Azure.DataApiBuilder.Config.ObjectModel;

namespace UI.Shared.SharedClasses.Mutables;

/// <summary>
/// Defines the Entities that are exposed.
/// </summary>
/// <param name="Source">The underlying database object to which the exposed entity is connected to.</param>
/// <param name="Rest">The JSON may represent this as a bool or a string and we use a custom <c>JsonConverter</c> to convert that into the .NET type.</param>
/// <param name="GraphQL">The JSON may represent this as a bool or a string and we use a custom <c>JsonConverter</c> to convert that into the .NET type.</param>
/// <param name="Permissions">Permissions assigned to this entity.</param>
/// <param name="Relationships">Defines how an entity is related to other exposed
/// entities and optionally provides details on what underlying database
/// objects can be used to support such relationships.</param>
/// <param name="Mappings">Defines mappings between database fields and GraphQL and REST fields.</param>
public class MutableEntity
{
    public const string PROPERTY_PATH = "path";
    public const string PROPERTY_METHODS = "methods";

    public EntitySource Source { get; set; }
    public MutableEntityGraphQLOptions GraphQL { get; set; }
    public MutableEntityRestOptions Rest { get; set; }
    public EntityPermission[] Permissions { get; set; }
    public Dictionary<string, string>? Mappings { get; set; }
    public Dictionary<string, EntityRelationship>? Relationships { get; set; }

    public MutableEntity(Entity entity)
    {
        Source = entity.Source;
        GraphQL = new MutableEntityGraphQLOptions(entity.GraphQL.Singular, entity.GraphQL.Plural, entity.GraphQL.Enabled, entity.GraphQL.Operation);
        Rest = new MutableEntityRestOptions(entity.Rest.Methods, entity.Rest.Path, entity.Rest.Enabled);
        Permissions = entity.Permissions;
        Mappings = entity.Mappings;
        Relationships = entity.Relationships;
    }
}
