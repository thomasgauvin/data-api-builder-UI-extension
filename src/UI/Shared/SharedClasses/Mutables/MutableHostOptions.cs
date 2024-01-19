// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Azure.DataApiBuilder.Config.ObjectModel;

namespace UI.Shared.SharedClasses.Mutables
{
    public class MutableHostOptions
    {
        public MutableCorsOptions? Cors { get; set; }
        public AuthenticationOptions? Authentication { get; set; }
        public HostMode Mode { get; set; } = HostMode.Production;
    }
}
