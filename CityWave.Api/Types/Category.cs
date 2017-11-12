using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CityWave.Api.Types
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
