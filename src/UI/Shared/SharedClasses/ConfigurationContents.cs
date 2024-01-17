using Azure.DataApiBuilder.Config.ObjectModel;

namespace UI.Shared.SharedClasses
{
    public class ConfigurationContents
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseType { get; set; }
        public bool? RestEnabled { get; set; }
        public string? RestPath { get; set; }
        public bool? GraphQlEnabled { get; set; }
        public string? GraphQlPath { get; set; }
        public string? CorsOriginsAsString { get; set; }
        public string? AuthenticationProvider { get; set; }

        public IDictionary<string, Entity>? Entities { get; set; }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }
}
