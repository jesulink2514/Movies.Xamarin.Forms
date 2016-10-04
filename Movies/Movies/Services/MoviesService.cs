using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Movies.Services;

namespace Movies
{
    public class MoviesService
    {
        private readonly HttpClient _httpClient;

        public const string BaseUrl = "http://www.omdbapi.com?apikey={0}&s={1}&r=json&page=1";

        public const string ApiKey = "API-KEY-HERE";

        public MoviesService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Movie>> SearchMoviesAsync(string query)
        {
            var response = await _httpClient.GetAsync(string.Format(BaseUrl, ApiKey, query));
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsAsync<MovieResponse>();
                return resp.Search.ToList();
            }
            return new List<Movie>();
        }

    }
}
