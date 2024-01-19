// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Represents the options for telemetry.
/// </summary>
/// <remarks>This record is mutable.</remarks>
public record TelemetryOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TelemetryOptions"/> class.
    /// </summary>
    /// <param name="applicationInsights">The Application Insights options.</param>
    public TelemetryOptions(ApplicationInsightsOptions? applicationInsights)
    {
        ApplicationInsights = applicationInsights;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TelemetryOptions"/> class.
    /// </summary>
    public TelemetryOptions()
    {
        ApplicationInsights = default!;
    }

    /// <summary>
    /// Gets or sets the Application Insights options.
    /// </summary>
    public ApplicationInsightsOptions? ApplicationInsights { get; set; }
}
