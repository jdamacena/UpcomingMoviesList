using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UpcomingMoviesList.ApiClient;
using Xamarin.Forms.Extended;

namespace UpcomingMoviesList
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private const int PAGE_SIZE = 20;
        private bool _isBusy;
        readonly RestService _service = new RestService();

        public event PropertyChangedEventHandler PropertyChanged;

        public InfiniteScrollCollection<Movie> Items { get; }

        public MainPageViewModel()
        {
            
            Items = new InfiniteScrollCollection<Movie>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;

                    // Read the next page
                    var page = Items.Count > 0 ? Items.Count / PAGE_SIZE : 1;
                    
                    var items = await _service.GetMoviesAsync(page);

                    IsBusy = false;
                    
                    return items;
                }
            };

            Download();
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
        private async Task Download()
        {
            var items = await _service.GetMoviesAsync(pageIndex: 1);

            Items.AddRange(items);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
