// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel
{
    /// <summary>
    /// DataSourceFiles is a record that contains a list of files defining the runtime configs for multi-db scenario.
    /// SourceFiles is null for single-db scenario.
    /// </summary>
    /// <remarks>This record is mutable.</remarks>
    public record DataSourceFiles
    {
        /// <summary>
        /// File names would match guidance as described in FileSystemRuntimeConfigLoader.cs
        /// </summary>
        /// <param name="SourceFiles">File names would match guidance as described in FileSystemRuntimeConfigLoader.cs</param>
        public DataSourceFiles(IEnumerable<string>? SourceFiles = null)
        {
            this.SourceFiles = SourceFiles;
        }

        /// <summary>
        /// Gets or sets the file names.
        /// </summary>
        public IEnumerable<string>? SourceFiles { get; set; }
    }
}
