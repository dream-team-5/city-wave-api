using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CityWave.Api.Types
{
    public class Request<T>
    {
        private const string host = "city-wave.herokuapp.com";
        private const string scheme = "https";

        private RequestMethod _method;
        private Uri _uri;
        private HttpContent _content;

        public Request(RequestMethod method, string path) : this(method, path, null) { }

        public Request(RequestMethod method, string path, IDictionary<string, string> parameters)
        {
            _method = method;

            _uri = new UriBuilder(scheme, host) { Path = path, Query = parameters?.ToQueryString() }.Uri;
        }

        public Request(RequestMethod method, string path, IDictionary<string, string> parameters, IDictionary<string, string> data)
            : this(method, path, parameters)
            => _content = new StringContent(data?.ToJson(), Encoding.UTF8, "application/json");

        public async Task<Response<T>> GetResponse()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                switch (_method)
                {
                    case RequestMethod.Get:
                        response = await client.GetAsync(_uri);
                        break;
                    case RequestMethod.Post:
                        response = await client.PostAsync(_uri, _content);
                        break;
                    case RequestMethod.Put:
                        response = await client.PutAsync(_uri, _content);
                        break;
                    default:
                        return null;
                }

                return JsonConvert.DeserializeObject<Response<T>>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
