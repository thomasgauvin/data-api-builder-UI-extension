// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Describes the REST settings specific to an entity.
/// </summary>
/// <remarks>This record is mutable.</remarks>
public record EntityRestOptions
{
    /// <summary>
    /// Instructs the runtime to use this as the path
    /// at which the REST endpoint for this entity is exposed
    /// instead of using the entity-name. Can be a string type.
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// The HTTP verbs that are supported for this entity. Has significance only for stored-procedures.
    /// For tables and views, all the 5 HTTP actions are enabled when REST endpoints are enabled 
    /// for the entity. So, this property is insignificant for tables and views.
    /// </summary>
    public SupportedHttpVerb[]? Methods { get; set; }

    /// <summary>
    /// Whether the entity is enabled for REST.
    /// </summary>
    public bool Enabled { get; set; }

    public static readonly SupportedHttpVerb[] DEFAULT_SUPPORTED_VERBS = new[] { SupportedHttpVerb.Get, SupportedHttpVerb.Post, SupportedHttpVerb.Put, SupportedHttpVerb.Patch, SupportedHttpVerb.Delete };
    public static readonly SupportedHttpVerb[] DEFAULT_HTTP_VERBS_ENABLED_FOR_SP = new[] { SupportedHttpVerb.Post };

    public EntityRestOptions(SupportedHttpVerb[]? methods = null, string? path = null, bool enabled = true)
    {
        Methods = methods;
        Path = path;
        Enabled = enabled;
    }

    public EntityRestOptions()
    {
        Path = default!;
        Methods = Array.Empty<SupportedHttpVerb>();
        Enabled = default;
    }
}
