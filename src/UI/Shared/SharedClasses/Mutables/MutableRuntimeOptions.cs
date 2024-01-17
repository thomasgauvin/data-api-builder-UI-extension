// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace UI.Shared.SharedClasses.Mutables
{
    public class MutableRuntimeOptions
    {
        public MutableRestRuntimeOptions Rest { get; set; } = new MutableRestRuntimeOptions();
        public MutableGraphQLRuntimeOptions GraphQL { get; set; } = new MutableGraphQLRuntimeOptions();

        public MutableHostOptions Host { get; set; } = new MutableHostOptions();
    }
}
