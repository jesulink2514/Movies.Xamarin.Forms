using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Services;
using Xamarin.Forms;

namespace Movies
{
    public partial class MoveDetailPage : ContentPage
    {
        public MoveDetailPage(Movie detail)
        {
            InitializeComponent();
            this.BindingContext = detail;
        }
    }
}
