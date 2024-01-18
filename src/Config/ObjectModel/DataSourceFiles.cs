// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel
{
    /// <summary>
    /// DataSourceFiles is a record that contains a list of files defining the runtime configs for multi-db scenario.
    /// SourceFiles is null for single-db scenario.
    /// </summary>
    /// <param name="SourceFiles">File names would match guidance as described in FileSystemRuntimeConfigLoader.cs</param>
    public class DataSourceFiles
    {
        /// <summary>
        /// Gets or sets the file names that match the guidance as described in FileSystemRuntimeConfigLoader.cs.
        /// </summary>
        public IEnumerable<string>? SourceFiles { get; set; }

        /// <summary>
        /// Initializes a new instance of the DataSourceFiles class.
        /// </summary>
        /// <param name="sourceFiles">The file names that match the guidance as described in FileSystemRuntimeConfigLoader.cs.</param>
        public DataSourceFiles(IEnumerable<string>? sourceFiles)
        {
            SourceFiles = sourceFiles;
        }
    }
}
