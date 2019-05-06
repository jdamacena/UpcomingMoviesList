using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace UpcomingMoviesList.Converters
{
    class GenreIdListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Dictionary<string, string> genres = new Dictionary<string, string>()
            {
                {"28", "Action" },
                {"12", "Adventure" },
                {"16", "Animation" },
                {"35", "Comedy" },
                {"80", "Crime" },
                {"99", "Documentary" },
                {"18", "Drama" },
                {"10751", "Family" },
                {"14", "Fantasy" },
                {"36", "History" },
                {"27", "Horror" },
                {"10402", "Music" },
                {"9648", "Mystery" },
                {"10749", "Romance" },
                {"878", "Science Fiction" },
                {"10770", "TV Movie" },
                {"53", "Thriller" },
                {"10752", "War" },
                {"37", "Western" }
            };

            List<string> genreIdList = (List<string>)value;

            var genreList = (from string genreId in genreIdList
                             let hasGenre = genres.ContainsKey(genreId)
                             where hasGenre
                             select genres[genreId]
                             ).ToList();
            
            return string.Join(", ", genreList);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
