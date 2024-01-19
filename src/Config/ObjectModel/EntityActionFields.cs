// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <remarks>This record is mutable.</remarks>
public record EntityActionFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityActionFields"/> class.
    /// </summary>
    /// <param name="exclude">The fields to exclude.</param>
    /// <param name="include">The fields to include.</param>
    public EntityActionFields(HashSet<string> exclude, HashSet<string>? include = null)
    {
        Exclude = exclude;
        Include = include;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityActionFields"/> class.
    /// </summary>

    public EntityActionFields()
    {
        Exclude = new HashSet<string>();
        Include = null;
    }

    /// <summary>
    /// Gets or sets the fields to exclude.
    /// </summary>
    public HashSet<string> Exclude { get; set; }

    /// <summary>
    /// Gets or sets the fields to include.
    /// </summary>
    public HashSet<string>? Include { get; set; }
}
