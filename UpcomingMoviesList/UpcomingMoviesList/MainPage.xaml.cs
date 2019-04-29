using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace UpcomingMoviesList
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Movie_Clicked(object sender, EventArgs e)
        {
            Element element = (Element)sender;
            Movie movie = (Movie)element.BindingContext;

            var movieDetailsPage = new MovieDetailsPage
            {
                BindingContext = movie
            };

            await Navigation.PushAsync(movieDetailsPage);
        }
    }
}
