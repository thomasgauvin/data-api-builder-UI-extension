// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// EntityActionFields
/// </summary>
/// <remarks>
/// This type is mutable.
/// </remarks>
public class EntityActionFields
{
    /// <summary>
    /// This type is mutable.
    /// </summary>
    /// <param name="exclude">Exclude cannot be null, it is initialized with an empty set - no field is excluded.</param>
    /// <param name="include">Include being null indicates that it was not specified in the config.
    /// This is used later (in authorization resolver) as an indicator that
    /// Include resolves to all fields present in the config.
    /// And so, unlike Exclude, we don't initialize it with an empty set when null.</param>
    public EntityActionFields(HashSet<string> exclude, HashSet<string>? include = null)
    {
        Exclude = exclude;
        Include = include;
    }

    /// <summary>
    /// Exclude cannot be null, it is initialized with an empty set - no field is excluded.
    /// </summary>
    public HashSet<string> Exclude { get; set; }

    /// <summary>
    /// Include being null indicates that it was not specified in the config.
    /// This is used later (in authorization resolver) as an indicator that
    /// Include resolves to all fields present in the config.
    /// And so, unlike Exclude, we don't initialize it with an empty set when null.
    /// </summary>
    public HashSet<string>? Include { get; set; }
}
