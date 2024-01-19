// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// DataSourceFiles is a record that contains a list of files defining the runtime configs for multi-db scenario.
/// SourceFiles is null for single-db scenario.
/// </summary>
/// <remarks>This record is mutable.</remarks>
public record DataSourceFiles
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataSourceFiles"/> class.
    /// </summary>
    /// <param name="sourceFiles">File names would match guidance as described in FileSystemRuntimeConfigLoader.cs</param>
    public DataSourceFiles(IEnumerable<string>? sourceFiles = null)
    {
        SourceFiles = sourceFiles;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataSourceFiles"/> class.
    /// </summary>
    public DataSourceFiles()
    {
        SourceFiles = default!;
    }

    /// <summary>
    /// Gets or sets the file names that match guidance as described in FileSystemRuntimeConfigLoader.cs.
    /// </summary>
    /// <value>The file names.</value>
    public IEnumerable<string>? SourceFiles { get; set; }
}
