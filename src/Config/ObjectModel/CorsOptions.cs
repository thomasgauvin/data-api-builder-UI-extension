// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Configuration related to Cross Origin Resource Sharing (CORS).
/// </summary>
/// <param name="Origins">List of allowed origins.</param>
/// <param name="AllowCredentials">
/// Whether to set Access-Control-Allow-Credentials CORS header.</param>
/// <remarks>
/// This type is mutable.
/// </remarks>
public class CorsOptions
{
    public string[] Origins { get; set; }
    public bool AllowCredentials { get; set; }

    public CorsOptions(string[] origins, bool allowCredentials = false)
    {
        Origins = origins;
        AllowCredentials = allowCredentials;
    }
}
