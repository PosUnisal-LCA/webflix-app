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
	public partial class ListaMovie : ContentPage
	{
        List<Model.Movie.Movie> lstMovie { get; set; }

        public ListaMovie ()
		{
			InitializeComponent ();
            this.baixarMovie();

        }


        public void bind()
        {

            BindingContext = null;
            BindingContext = this.lstMovie;


        }


        public async void baixarMovie()
        {
            try
            {
                lstMovie = await Sistema.Sistema.RESTAPI.getMoviesAsync();
                this.listaMovie.ItemsSource = lstMovie;

                bind();

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var page = new MenuDetail((e.Item as Model.Movie.Movie));
            await Navigation.PushAsync(page);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    
}
}