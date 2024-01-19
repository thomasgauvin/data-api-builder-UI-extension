// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Holds the global settings used at runtime for REST APIs.
/// </summary>
/// <remarks>This class is mutable.</remarks>
public class RestRuntimeOptions
{
    public bool Enabled { get; set; }
    public string Path { get; set; }
    public bool RequestBodyStrict { get; set; }

    public const string DEFAULT_PATH = "/api";

    /// <summary>
    /// Initializes a new instance of the <see cref="RestRuntimeOptions"/> class.
    /// </summary>
    /// <param name="enabled">If the REST APIs are enabled.</param>
    /// <param name="path">The URL prefix path at which endpoints
    /// for all entities will be exposed.</param>
    /// <param name="requestBodyStrict">Boolean property indicating whether extraneous fields are allowed in request body.
    /// The default value is true - meaning we don't allow extraneous fields by default in the rest request body.
    /// Changing the default value is a breaking change.</param>
    public RestRuntimeOptions(bool enabled = true, string path = RestRuntimeOptions.DEFAULT_PATH, bool requestBodyStrict = true)
    {
        Enabled = enabled;
        Path = path;
        RequestBodyStrict = requestBodyStrict;
    }
}
