// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Text;
using UI.Shared.SharedClasses;
using Azure.DataApiBuilder.Config.ObjectModel;
using System.Net.Http.Json;
using DatabaseType = UI.Shared.SharedClasses.DatabaseType;

namespace UI.Pages
{
    public partial class Configuration : ComponentBase
    {
        [CascadingParameter]
        protected MutableRuntimeConfig? MutableRuntimeConfig { get; set; }

        private async Task<HttpResponseMessage> PublishNewConfig()
        {
            Console.WriteLine("Publish Button Clicked!");
            // Perform http operation on endpoint.

            string json = JsonSerializer.Serialize(MutableRuntimeConfig);
            ConfigurationPostParameters configParam =
                new(Configuration: json,
                    Schema: null,
                    ConnectionString: MutableRuntimeConfig!.MutableDataSource.ConnectionString!,
                    AccessToken: null);

            string configurationEndpoint = "https://localhost:5001/configuration";

            using (HttpClient httpClient = new())
            {
                JsonContent jsonContent =
                    JsonContent.Create(configParam, typeof(ConfigurationPostParameters));
                return await httpClient.PostAsync(configurationEndpoint, jsonContent);
            }
        }

        private void SaveNewConfig()
        {
            string json = JsonSerializer.Serialize(MutableRuntimeConfig);
            Byte[] byteArray = Encoding.UTF8.GetBytes(json);
            MemoryStream fileStream = new(byteArray);
            string fileName = "dab-config-ui-modified.json";
            Console.WriteLine(fileName);
            using DotNetStreamReference streamRef = new(stream: fileStream);
            //GetFileStream();
        }

        private List<DatabaseType> _databaseTypes = new()
        {
            new DatabaseType { Label = "Azure SQL", Value = "mssql" },
            new DatabaseType { Label = "CosmosDB for NoSQL", Value = "cosmosdb_nosql" },
            new DatabaseType { Label = "PostgreSQL", Value = "postgresql" },
            new DatabaseType { Label = "MySQL", Value = "mysql" }
        };

        protected void LogJSON()
        {
            Console.WriteLine("logging");
            string value = MutableRuntimeConfig?.ToJson() ?? "";
            Console.WriteLine(value);
        }
    }
}
