// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Represents the options for telemetry.
/// </summary>
public class TelemetryOptions
{
    /// <summary>
    /// Gets or sets the Application Insights options.
    /// </summary>
    public ApplicationInsightsOptions? ApplicationInsights { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TelemetryOptions"/> class.
    /// </summary>
    /// <param name="applicationInsights">The Application Insights options.</param>
    public TelemetryOptions(ApplicationInsightsOptions? applicationInsights)
    {
        ApplicationInsights = applicationInsights;
    }
}
