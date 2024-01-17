using Azure.DataApiBuilder.Config.ObjectModel;
using UI.Shared.SharedClasses.Mutables;

namespace UI.Shared.SharedClasses
{
    public class MutableRuntimeConfig
    {
        public MutableDataSource MutableDataSource { get; set; }
        public MutableRuntimeOptions MutableRuntimeOptions { get; set; }
        public MutableRuntimeEntities MutableRuntimeEntities { get; set; }

        public MutableRuntimeConfig(RuntimeConfig runtimeConfig)
        {
            MutableRuntimeEntities = new MutableRuntimeEntities(runtimeConfig.Entities.Entities);

            MutableRuntimeOptions = new MutableRuntimeOptions
            {
                Rest = new MutableRestRuntimeOptions
                {
                    Enabled = runtimeConfig.IsRestEnabled,
                    Path = runtimeConfig.RestPath
                },
                GraphQL = new MutableGraphQLRuntimeOptions
                {
                    Enabled = runtimeConfig.IsGraphQLEnabled,
                    Path = runtimeConfig.GraphQLPath
                },
                Host = new MutableHostOptions
                {
                    Mode = runtimeConfig.Runtime!.Host!.Mode,
                    Cors = new MutableCorsOptions
                    {
                        Origins = $"[{string.Join(", ", runtimeConfig.Runtime!.Host!.Cors!.Origins)}]"
                    }
                }
            };
            MutableDataSource = new MutableDataSource
            {
                ConnectionString = runtimeConfig.DataSource.ConnectionString,
                //if runtime.DataSource.DatabaseType is in DatabaseType enum, then set it to that, otherwise set it to DatabaseType.Unknown
                DatabaseType = DatabaseType.GetDatabaseTypeFromDatabaseTypeEnum(runtimeConfig.DataSource.DatabaseType).ToString() ?? new DatabaseType { Label = "Azure SQL", Value = "mssql" }.ToString(),
            };
        }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }

        //public RuntimeConfig ToRuntimeConfig()
        //{
        //    return new RuntimeConfig
        //    {
        //        //DataSource = MutableDataSource?.ToDataSource(),
        //        //RuntimeEntities = MutableRuntimeEntities?.ToRuntimeEntities(),
        //        RuntimeOptions = MutableRuntimeOptions?.ToRuntimeOptions(),
        //    };
        //}
    }
}
