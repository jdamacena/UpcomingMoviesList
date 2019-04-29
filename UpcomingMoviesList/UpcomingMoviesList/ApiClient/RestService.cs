using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace UpcomingMoviesList.ApiClient
{
    public class RestService
    {
        HttpClient _client;
        private readonly string BaseImageUrl = "https://image.tmdb.org/t/p/w500";
        private readonly string ApiKey = "1f54bd990f1cdfb230adb312546d765d";

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Movie>> GetMoviesAsync(int pageIndex)
        {
            var Items = new List<Movie>();

            var uri = new Uri($"https://api.themoviedb.org/3/movie/upcoming?api_key={ApiKey}&language=en-US&page={pageIndex}&region=US");

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JObject.Parse(content);
                    var items = result["results"];
                    string jsonResult = items.ToString();

                    Items = JsonConvert.DeserializeObject<List<Movie>>(jsonResult);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            // Transformations on the objects of the list
            foreach (var movie in Items)
            {
                movie.PosterUrl = BaseImageUrl + movie.PosterUrl;
            }

            return Items;
        }
    }
}
