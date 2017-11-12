using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CityWave.Api.Types
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Response<T>
    {
        public bool Ok { get; set; }

        public object Description { get; set; }

        public T Result { get; set; }

        public void Process(Action<T> success, Action<object> failure)
        {
            if (Ok)
                success?.Invoke(Result);
            else
                failure?.Invoke(Description);
        }
    }
}
