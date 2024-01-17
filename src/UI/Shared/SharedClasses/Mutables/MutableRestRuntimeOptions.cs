// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace UI.Shared.SharedClasses.Mutables;

public class MutableRestRuntimeOptions
{
    public bool Enabled { get; set; }
    public string Path { get; set; } = "";
    public bool RequestBodyStrict { get; set; }
}
