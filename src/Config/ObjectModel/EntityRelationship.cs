// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <remarks>
/// This type is mutable.
/// </remarks>
public class EntityRelationship
{
    [JsonPropertyName("cardinality")]
    public Cardinality Cardinality { get; set; }

    [JsonPropertyName("target.entity")]
    public string TargetEntity { get; set; }

    [JsonPropertyName("source.fields")]
    public string[] SourceFields { get; set; }

    [JsonPropertyName("target.fields")]
    public string[] TargetFields { get; set; }

    [JsonPropertyName("linking.object")]
    public string? LinkingObject { get; set; }

    [JsonPropertyName("linking.source.fields")]
    public string[] LinkingSourceFields { get; set; }

    [JsonPropertyName("linking.target.fields")]
    public string[] LinkingTargetFields { get; set; }

    public EntityRelationship(
        Cardinality cardinality,
        string targetEntity,
        string[] sourceFields,
        string[] targetFields,
        string? linkingObject,
        string[] linkingSourceFields,
        string[] linkingTargetFields)
    {
        Cardinality = cardinality;
        TargetEntity = targetEntity;
        SourceFields = sourceFields;
        TargetFields = targetFields;
        LinkingObject = linkingObject;
        LinkingSourceFields = linkingSourceFields;
        LinkingTargetFields = linkingTargetFields;
    }
}
