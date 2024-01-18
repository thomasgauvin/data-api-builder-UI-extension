// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Represents the options for configuring Application Insights.
/// </summary>
/// <remarks>
/// This type is mutable.
/// </remarks>
public class ApplicationInsightsOptions
{
    public bool Enabled { get; set; }
    public string? ConnectionString { get; set; }

    public ApplicationInsightsOptions(bool enabled = false, string? connectionString = null)
    {
        Enabled = enabled;
        ConnectionString = connectionString;
    }
}
