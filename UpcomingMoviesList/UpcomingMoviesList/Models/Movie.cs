using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UpcomingMoviesList
{
    public class Movie
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("original_title")]
        public string Title { get; set; }
        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }
        [JsonProperty("genre_ids")]
        public List<string> Genres { get; set; }
        [JsonProperty("backdrop_path")]
        public string PosterUrl { get; set; }
        [JsonProperty("overview")]
        public string Overview { get; set; }
    }
}
