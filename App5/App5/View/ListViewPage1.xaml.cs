using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : ContentPage
    {

        List<Model.Usuario.Usuario> lstusuario { get; set; }

        public ListViewPage1()
        {
            InitializeComponent();

            this.baixarUsuario();


        }

        public void bind()
        {

            BindingContext = null;
            BindingContext = this.lstusuario;


        }


        public async void baixarUsuario()
        {
            try
            {
                lstusuario = await Sistema.Sistema.RESTAPI.getUsuariosAsync();
                this.listaUsuario.ItemsSource = lstusuario;
             
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

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
