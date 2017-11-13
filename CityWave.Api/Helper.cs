using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CityWave.Api
{
    public static class Helper
    {
        private static readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }
        };

        public static string ToJson(this object obj)
            => JsonConvert.SerializeObject(obj, Formatting.None, jsonSettings);

        public static string ToQueryString(this IDictionary<string, string> dictionary)
        {
            var parameters = dictionary
                .Where(kvp => kvp.Value != null)
                .Select(kvp => $"{ kvp.Key }={ WebUtility.UrlEncode(kvp.Value) }");

            return string.Join("&", parameters);
        }
    }
}
