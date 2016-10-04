using Movies.Services;
using Xamarin.Forms;

namespace Movies
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var movie = e.Item as Movie;
            await Navigation.PushAsync(new MoveDetailPage(movie));
        }
    }
}
