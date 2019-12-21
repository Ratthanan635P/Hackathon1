using EWalletAdminApp.View;
using EWalletAdminApp.View.PopUp;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EWalletAdminApp
{
	public partial class App : Application
	{
		public static Uri BaseUri { get; private set; }
		public static string Email { get;  set; }
		public static string NameShop { get; set; }
		public static int UserId { get; set; }
		public static int Main { get; set; }
		public App()
		{
			InitializeComponent();
			BaseUri = new Uri("http://192.168.1.29:30000/");
			Email = "";
			NameShop = "";
			UserId = 0;
			Main = 0;
			MainPage =new NavigationPage( new MainPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
