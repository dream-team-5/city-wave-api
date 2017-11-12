using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CityWave.Api.Types
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Profile
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserRoles[] Roles { get; set; }
    }
}
