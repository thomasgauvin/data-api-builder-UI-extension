// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.DataApiBuilder.Config.ObjectModel;

namespace UI.Shared.SharedClasses.Mutables
{
    class RuntimeEntitiesConverter : JsonConverter<MutableRuntimeEntities>
    {
        /// <inheritdoc/>
        public override MutableRuntimeEntities? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            IDictionary<string, Entity> entities =
                JsonSerializer.Deserialize<Dictionary<string, Entity>>(ref reader, options) ??
                throw new JsonException("Failed to read entities");

            return new MutableRuntimeEntities(new Dictionary<string, Entity>(entities));
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, MutableRuntimeEntities value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            foreach ((string key, MutableEntity entity) in value.Entities)
            {
                writer.WritePropertyName(key);
                JsonSerializer.Serialize(writer, entity, options);
            }

            writer.WriteEndObject();
        }
    }

}

