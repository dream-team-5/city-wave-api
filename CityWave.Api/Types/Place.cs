using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CityWave.Api.Types
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Place
    {
        public long Id { get; set; }

        public long CityId { get; set; }

        public long CategoryId { get; set; }

        public long[] TagIds { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Contacts { get; set; }

        public decimal Price { get; set; }

        public string PhotoUrl { get; set; }
    }
}
