using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDetail : ContentPage
    {
        List<Model.Movie.Movie> m = new List<Model.Movie.Movie>(); 
        public MenuDetail()
        {
            InitializeComponent();
            buscarFilme();

        }

        public MenuDetail(Model.Movie.Movie _m)
        {
            InitializeComponent();
            this.m.Add(_m);
            this.bind();

        }

        public async Task bind()
        {

            BindingContext = null;
            BindingContext = this.m.FirstOrDefault();

        }
        public async void buscarFilme ()
        {
            m = await Sistema.Sistema.RESTAPI.getMoviesAsync();
            await this.bind();

        }
        
    }
}