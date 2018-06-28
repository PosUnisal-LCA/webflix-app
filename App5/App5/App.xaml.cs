using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace App5
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            Sistema.Sistema.RESTAPI = new Rest.Rest("https://webflix-lca.herokuapp.com/api/v1/");
            
            MainPage = new NavigationPage(new View.Login());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
