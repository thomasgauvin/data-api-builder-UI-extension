// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// This record is mutable.
/// </summary>
public record EntityRelationship
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityRelationship"/> class.
    /// </summary>
    /// <param name="cardinality">The cardinality.</param>
    /// <param name="targetEntity">The target entity.</param>
    /// <param name="sourceFields">The source fields.</param>
    /// <param name="targetFields">The target fields.</param>
    /// <param name="linkingObject">The linking object.</param>
    /// <param name="linkingSourceFields">The linking source fields.</param>
    /// <param name="linkingTargetFields">The linking target fields.</param>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityRelationship"/> class.
    /// </summary>
    public EntityRelationship()
    {
        Cardinality = default!;
        TargetEntity = default!;
        SourceFields = Array.Empty<string>();
        TargetFields = Array.Empty<string>();
        LinkingObject = null;
        LinkingSourceFields = Array.Empty<string>();
        LinkingTargetFields = Array.Empty<string>();
    }

    /// <summary>
    /// Gets or sets the cardinality.
    /// </summary>
    public Cardinality Cardinality { get; set; }

    /// <summary>
    /// Gets or sets the target entity.
    /// </summary>
    [property: JsonPropertyName("target.entity")]
    public string TargetEntity { get; set; }

    /// <summary>
    /// Gets or sets the source fields.
    /// </summary>
    [property: JsonPropertyName("source.fields")]
    public string[] SourceFields { get; set; }

    /// <summary>
    /// Gets or sets the target fields.
    /// </summary>
    [property: JsonPropertyName("target.fields")]
    public string[] TargetFields { get; set; }

    /// <summary>
    /// Gets or sets the linking object.
    /// </summary>
    [property: JsonPropertyName("linking.object")]
    public string? LinkingObject { get; set; }

    /// <summary>
    /// Gets or sets the linking source fields.
    /// </summary>
    [property: JsonPropertyName("linking.source.fields")]
    public string[] LinkingSourceFields { get; set; }

    /// <summary>
    /// Gets or sets the linking target fields.
    /// </summary>
    [property: JsonPropertyName("linking.target.fields")]
    public string[] LinkingTargetFields { get; set; }
}
