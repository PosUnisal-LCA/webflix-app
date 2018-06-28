using Rg.Plugins.Popup.Services;
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
	public partial class CadastrarUsuario : ContentPage
	{
		public CadastrarUsuario ()
		{
			InitializeComponent ();
		}

        public async void salvarUsuario()
        {
            await PopupNavigation.PushAsync(new ModalCarregamento("Salvando dados"));
            Model.Usuario.Usuario s = new Model.Usuario.Usuario()
            {
                login = txtLogin.Text,
                name = txtNome.Text,
                senha = txtSenha.Text,

            };
            
            try
            {
               Sistema.Sistema.usuario =  await Sistema.Sistema.RESTAPI.postUsuariosAsync(s);
                await PopupNavigation.PopAsync();
                await Navigation.PushModalAsync(new View.Login());

            }
            catch (Exception e)
            {
                await PopupNavigation.PopAsync();
                await DisplayAlert("", "Erro ao cadastrar usuario " + e.Message, "ok");
            }
        }
    }
}