using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace CityWave.Api.Types
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Comment
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public long PlaceId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
