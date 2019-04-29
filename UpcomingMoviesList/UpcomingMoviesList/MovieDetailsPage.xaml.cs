using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UpcomingMoviesList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailsPage : ContentPage
    {
        public Movie Movie { get; set; }

        public MovieDetailsPage()
        {
            InitializeComponent();
        }
    }
}