// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace UI.Shared.SharedClasses
{
    public class DatabaseType
    {
        public string Label { get; set; } = "";
        public string Value { get; set; } = "";

        //public Azure.DataApiBuilder.Config.ObjectModel.DatabaseType GetEnumValue()
        //{
        //    if (Value == "mssql")
        //        return Azure.DataApiBuilder.Config.ObjectModel.DatabaseType.MSSQL;
        //    if (Value == "cosmosdb_nosql")
        //        return Azure.DataApiBuilder.Config.ObjectModel.DatabaseType.CosmosDB_NoSQL;
        //    if (Value == "postgresql")
        //        return Azure.DataApiBuilder.Config.ObjectModel.DatabaseType.PostgreSQL;
        //    if (Value == "mysql")
        //        return Azure.DataApiBuilder.Config.ObjectModel.DatabaseType.MySQL;

        //    return Azure.DataApiBuilder.Config.ObjectModel.DatabaseType.MSSQL;
        //}

        public override string ToString()
        {
            return Value;
        }

        public static DatabaseType GetDatabaseTypeFromDatabaseTypeEnum(Azure.DataApiBuilder.Config.ObjectModel.DatabaseType databaseTypeFromEnum)
        {
            if (databaseTypeFromEnum == Azure.DataApiBuilder.Config.ObjectModel.DatabaseType.MSSQL)
            {
                return new DatabaseType { Label = "Azure SQL", Value = "mssql" };
            }

            if (databaseTypeFromEnum == Azure.DataApiBuilder.Config.ObjectModel.DatabaseType.CosmosDB_NoSQL)
            {
                return new DatabaseType { Label = "CosmosDB for NoSQL", Value = "cosmosdb_nosql" };
            }

            if (databaseTypeFromEnum == Azure.DataApiBuilder.Config.ObjectModel.DatabaseType.PostgreSQL)
            {
                return new DatabaseType { Label = "PostgreSQL", Value = "postgresql" };
            }

            if (databaseTypeFromEnum == Azure.DataApiBuilder.Config.ObjectModel.DatabaseType.MySQL)
            {
                return new DatabaseType { Label = "MySQL", Value = "mysql" };
            }

            return new DatabaseType { Label = "Azure SQL", Value = "mssql" };
        }
    }
}
