using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CityWave.Api.Types
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ShortPlace
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhotoUrl { get; set; }
    }
}
