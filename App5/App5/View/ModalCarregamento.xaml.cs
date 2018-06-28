using Rg.Plugins.Popup.Pages;
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
	public partial class ModalCarregamento : PopupPage
    {
		public ModalCarregamento (string valor)
		{

            InitializeComponent();
            loading.IsRunning = true;
            lblIndicador.Text = valor;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}