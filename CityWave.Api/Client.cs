using CityWave.Api.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityWave.Api
{
    public class Client
    {
        private string _token;

        public Client(string token)
            => _token = token;

        #region Category

        public Task<Response<Category[]>> GetCategories()
        {
            var parameters = new Dictionary<string, string> { { "token", _token } };
            var request = new Request<Category[]>(RequestMethod.Get, "/categories", parameters);

            return request.GetResponse();
        }

        public Task<Response<ShortPlace[]>> GetCategoryPlaces(long categoryId, string name = null, int? page = null)
        {
            var parameters = new Dictionary<string, string> {
                { "token", _token },
                { "page", page?.ToString() },
                { "name", name }
            };
            var request = new Request<ShortPlace[]>(RequestMethod.Get, $"/categories/{ categoryId }/places", parameters);

            return request.GetResponse();
        }

        #endregion

        #region City

        public Task<Response<City[]>> GetCities()
        {
            var parameters = new Dictionary<string, string> { { "token", _token } };
            var request = new Request<City[]>(RequestMethod.Get, "/cities", parameters);

            return request.GetResponse();
        }

        public Task<Response<ShortPlace[]>> GetCityPlaces(long cityId, string name = null, int? page = null)
        {
            var parameters = new Dictionary<string, string> {
                { "token", _token },
                { "page", page?.ToString() },
                { "name", name }
            };
            var request = new Request<ShortPlace[]>(RequestMethod.Get, $"/cities/{ cityId }/places", parameters);

            return request.GetResponse();
        }

        #endregion

        #region Comment

        public Task<Response<City[]>> GetComments(int? page = null)
        {
            var parameters = new Dictionary<string, string> {
                { "token", _token },
                { "page", page?.ToString() }
            };
            var request = new Request<City[]>(RequestMethod.Get, "/comments", parameters);

            return request.GetResponse();
        }

        public Task<Response<ShortPlace[]>> CreateComment(long placeId, string text)
        {
            var parameters = new Dictionary<string, string> { { "token", _token } };
            var data = new Dictionary<string, string> { { "text", text } };

            var request = new Request<ShortPlace[]>(RequestMethod.Post, $"/places/{ placeId }/comments", parameters, data);

            return request.GetResponse();
        }

        #endregion

        #region Place

        public Task<Response<ShortPlace[]>> GetSavedPlaces(string name = null, int? page = null)
        {
            var parameters = new Dictionary<string, string> {
                { "token", _token },
                { "page", page?.ToString() },
                { "name", name }
            };
            var request = new Request<ShortPlace[]>(RequestMethod.Get, $"/saved_places", parameters);

            return request.GetResponse();
        }

        public Task<Response<Place>> CreateSavedPlace(long placeId)
        {
            var parameters = new Dictionary<string, string> { { "token", _token } };
            var data = new Dictionary<string, string> { { "place_id", placeId.ToString() } };

            var request = new Request<Place>(RequestMethod.Post, $"/saved_places", parameters, data);

            return request.GetResponse();
        }

        public Task<Response<ShortPlace[]>> GetVisitedPlaces(string name = null, int? page = null)
        {
            var parameters = new Dictionary<string, string> {
                { "token", _token },
                { "page", page?.ToString() },
                { "name", name }
            };
            var request = new Request<ShortPlace[]>(RequestMethod.Get, $"/visited_places", parameters);

            return request.GetResponse();
        }

        public Task<Response<Place>> CreateVisitedPlace(long placeId)
        {
            var parameters = new Dictionary<string, string> { { "token", _token } };
            var data = new Dictionary<string, string> { { "place_id", placeId.ToString() } };

            var request = new Request<Place>(RequestMethod.Post, $"/visited_places", parameters, data);

            return request.GetResponse();
        }

        public Task<Response<Place>> GetPlace(long placeId)
        {
            var parameters = new Dictionary<string, string> { { "token", _token } };
            var request = new Request<Place>(RequestMethod.Get, $"/places/{ placeId }", parameters);

            return request.GetResponse();
        }

        public Task<Response<Comment[]>> GetPlaceComments(long placeId, int? page = null)
        {
            var parameters = new Dictionary<string, string> {
                { "token", _token },
                { "page", page?.ToString() }
            };
            var request = new Request<Comment[]>(RequestMethod.Get, $"/places/{ placeId }/comments", parameters);

            return request.GetResponse();
        }

        #endregion

        #region Profile

        public Task<Response<Profile>> GetProfile()
        {
            var parameters = new Dictionary<string, string> { { "token", _token } };
            var request = new Request<Profile>(RequestMethod.Get, $"/profile", parameters);

            return request.GetResponse();
        }

        public static Task<Response<string>> CreateProfile()
        {
            var request = new Request<string>(RequestMethod.Post, $"/profile");

            return request.GetResponse();
        }

        public Task<Response<Profile>> UpdateProfile(string username, string password)
        {
            var parameters = new Dictionary<string, string> { { "token", _token } };
            var data = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            var request = new Request<Profile>(RequestMethod.Put, "/profile", parameters, data);

            return request.GetResponse();
        }

        public static async Task<Client> SignUp(Action<object> processError)
        {
            Client client = null;

            var tokenResponse = await CreateProfile();
            tokenResponse.Process(token => client = new Client(token), processError);

            return client;
        }

        public static async Task<Client> SignUp(string username, string password, Action<object> processError)
        {
            Client client = null;

            var tokenResponse = await CreateProfile();
            tokenResponse.Process(token => client = new Client(token), processError);

            var profileResponce = await client.UpdateProfile(username, password);
            profileResponce.Process(null, processError);

            return client;
        }

        #endregion

        #region Session

        public static Task<Response<string>> CreateSession(string username, string password)
        {
            var data = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };
            var request = new Request<string>(RequestMethod.Post, "/session", null, data);

            return request.GetResponse();
        }

        public static async Task<Client> SignIn(string username, string password, Action<object> processError)
        {
            Client client = null;

            var tokenResponse = await CreateSession(username, password);
            tokenResponse.Process(token => client = new Client(token), processError);

            return client;
        }

        #endregion

        #region Tag

        public Task<Response<Tag[]>> GetTags()
        {
            var parameters = new Dictionary<string, string> { { "token", _token } };
            var request = new Request<Tag[]>(RequestMethod.Get, "/tags", parameters);

            return request.GetResponse();
        }

        public Task<Response<ShortPlace[]>> GetTagPlaces(long tagId, string name = null, int? page = null)
        {
            var parameters = new Dictionary<string, string> {
                { "token", _token },
                { "page", page?.ToString() },
                { "name", name }
            };
            var request = new Request<ShortPlace[]>(RequestMethod.Get, $"/tags/{ tagId }/places", parameters);

            return request.GetResponse();
        }

        #endregion

        #region Wish

        public Task<Response<Wish>> GetWish()
        {
            var parameters = new Dictionary<string, string> { { "token", _token } };
            var request = new Request<Wish>(RequestMethod.Get, "/wish", parameters);

            return request.GetResponse();
        }

        #endregion
    }
}
