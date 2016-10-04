using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Acr.UserDialogs;
using Movies.Services;
using Xamarin.Forms;

namespace Movies
{
    public class MainViewModel:BindableObject
    {
        private string _search;
        private List<Movie> _result = new List<Movie>();

        public MainViewModel()
        {
            _service = new MoviesService();
        }

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged();
            }
        }

        public List<Movie> Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public bool AnyItem => Result.Any();

        public ICommand SearchCommand => new Command(async() =>
        {
            UserDialogs.Instance.ShowLoading("searching...");
            var result = await _service.SearchMoviesAsync(Search);
            this.Result = result;
            OnPropertyChanged("AnyItem");
            UserDialogs.Instance.HideLoading();
        });

        public ICommand ShareCommand => new Command<Movie>((movie) =>
        {
            Device.OpenUri(new Uri(movie.Poster));
        });

        private readonly MoviesService _service;
    }
}
