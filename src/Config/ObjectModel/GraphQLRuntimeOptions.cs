// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// This class is mutable.
/// </summary>
public class GraphQLRuntimeOptions
{
    public bool Enabled { get; set; } = true;
    public string Path { get; set; } = DEFAULT_PATH;
    public bool AllowIntrospection { get; set; } = true;

    public const string DEFAULT_PATH = "/graphql";

    public GraphQLRuntimeOptions(bool enabled = true, string path = DEFAULT_PATH, bool allowIntrospection = true)
    {
        Enabled = enabled;
        Path = path;
        AllowIntrospection = allowIntrospection;
    }
}
