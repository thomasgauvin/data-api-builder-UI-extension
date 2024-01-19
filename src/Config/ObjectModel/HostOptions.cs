// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// This class is mutable.
/// </summary>
public class HostOptions
{
    /// <summary>
    /// Gets or sets the CORS options.
    /// </summary>
    public CorsOptions? Cors { get; set; }

    /// <summary>
    /// Gets or sets the authentication options.
    /// </summary>
    public AuthenticationOptions? Authentication { get; set; }

    /// <summary>
    /// Gets or sets the host mode.
    /// </summary>
    public HostMode Mode { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HostOptions"/> class.
    /// </summary>
    /// <param name="cors">The CORS options.</param>
    /// <param name="authentication">The authentication options.</param>
    /// <param name="mode">The host mode.</param>
    public HostOptions(CorsOptions? cors, AuthenticationOptions? authentication, HostMode mode = HostMode.Production)
    {
        Cors = cors;
        Authentication = authentication;
        Mode = mode;
    }
}
