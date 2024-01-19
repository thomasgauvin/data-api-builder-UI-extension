// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Describes the type, name, parameters, and key fields for a
/// database object source.
/// </summary>
/// <remarks>
/// This type is mutable.
/// </remarks>
public class EntitySource
{
    /// <summary>
    /// The name of the database object.
    /// </summary>
    public string Object { get; set; }

    /// <summary>
    /// Type of the database object.
    /// Should be one of [table, view, stored-procedure].
    /// </summary>
    public EntitySourceType? Type { get; set; }

    /// <summary>
    /// If Type is SourceType.StoredProcedure,
    /// Parameters to be passed as defaults to the procedure call.
    /// </summary>
    public Dictionary<string, object>? Parameters { get; set; }

    /// <summary>
    /// The field(s) to be used as primary keys.
    /// </summary>
    public string[]? KeyFields { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntitySource"/> class.
    /// </summary>
    /// <param name="Object"> The name of the database object. </param>
    /// <param name="Type"> Type of the database object.
    /// Should be one of [table, view, stored-procedure]. </param>
    /// <param name="Parameters"> If Type is SourceType.StoredProcedure,
    /// Parameters to be passed as defaults to the procedure call </param>
    /// <param name="KeyFields"> The field(s) to be used as primary keys. </param>
    public EntitySource(string Object, EntitySourceType? Type, Dictionary<string, object>? Parameters, string[]? KeyFields)
    {
        this.Object = Object;
        this.Type = Type;
        this.Parameters = Parameters;
        this.KeyFields = KeyFields;
    }
}
