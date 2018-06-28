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
	public partial class Dados : ContentPage
	{
        Model.Usuario.Usuario u { get; set; }
		public Dados ()
		{
			InitializeComponent ();
            u = Sistema.Sistema.usuario;
            this.bind();
		}

        public async Task bind()
        {
            BindingContext = null;
            BindingContext = this.u;
        }

        public async void alterarUsuario()
        {
            if ((txtLogin.Text.Trim().Equals("")) && (txtLogin.Text.Trim().Equals("")) && (txtLogin.Text.Trim().Equals("")))
            {
                await DisplayAlert("","Preencha todos os campos","ok");
                return;
            }


            await PopupNavigation.PushAsync(new ModalCarregamento("Alterando dados"));
            try
            {
                await Sistema.Sistema.RESTAPI.putUsuarioAsync(u);
                await PopupNavigation.PopAsync();

            }
            catch (Exception e)
            {
                await PopupNavigation.PopAsync();
                await DisplayAlert("", "Erro ao alterar usuario " + e.Message, "ok");
            }
        }

        public async void excluirUsuario()
        {

            await PopupNavigation.PushAsync(new ModalCarregamento("Excluindo dados"));
            try
            {
                bool a = await Sistema.Sistema.RESTAPI.deleteUsuarioAsync(u);
                if (a)
                {
                    await PopupNavigation.PopAsync();
                    await Navigation.PushAsync(new Login());

                }
                else
                {
                    await PopupNavigation.PopAsync();
                    await DisplayAlert("", "Erro ao excluir usuario", "ok");
                }
               




            }
            catch (Exception e)
            {
                await PopupNavigation.PopAsync();
                await DisplayAlert("", "Erro ao excluir usuario " + e.Message, "ok");
            }
        }

    }
}