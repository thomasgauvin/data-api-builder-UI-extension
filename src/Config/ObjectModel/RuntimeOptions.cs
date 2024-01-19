// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// This record is mutable.
/// </summary>
public record RuntimeOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RuntimeOptions"/> class.
    /// </summary>
    /// <param name="rest">The REST runtime options.</param>
    /// <param name="graphQL">The GraphQL runtime options.</param>
    /// <param name="host">The host options.</param>
    /// <param name="baseRoute">The base route.</param>
    /// <param name="telemetry">The telemetry options.</param>
    public RuntimeOptions(
        RestRuntimeOptions? rest,
        GraphQLRuntimeOptions? graphQL,
        HostOptions? host,
        string? baseRoute = null,
        TelemetryOptions? telemetry = null)
    {
        Rest = rest;
        GraphQL = graphQL;
        Host = host;
        BaseRoute = baseRoute;
        Telemetry = telemetry;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RuntimeOptions"/> class.
    /// </summary>
    public RuntimeOptions()
    {
        Rest = default!;
        GraphQL = default!;
        Host = default!;
        BaseRoute = default!;
        Telemetry = default!;
    }

    /// <summary>
    /// Gets or sets the REST runtime options.
    /// </summary>
    public RestRuntimeOptions? Rest { get; set; }

    /// <summary>
    /// Gets or sets the GraphQL runtime options.
    /// </summary>
    public GraphQLRuntimeOptions? GraphQL { get; set; }

    /// <summary>
    /// Gets or sets the host options.
    /// </summary>
    public HostOptions? Host { get; set; }

    /// <summary>
    /// Gets or sets the base route.
    /// </summary>
    public string? BaseRoute { get; set; }

    /// <summary>
    /// Gets or sets the telemetry options.
    /// </summary>
    public TelemetryOptions? Telemetry { get; set; }
}
