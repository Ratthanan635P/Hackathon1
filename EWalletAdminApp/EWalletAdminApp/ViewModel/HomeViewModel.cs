using EWalletAdminApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EWalletAdminApp.ViewModel
{
	public class HomeViewModel:BaseViewModel
	{
		public ICommand TopUpCommand { get; set; }
		public ICommand HomeCommand { get; set; }
		public ICommand HistoryCommand { get; set; }
		public HomeViewModel()
		{
			HomeCommand = new Command(GotoHomePage, () => false);
			TopUpCommand = new Command(GotoTopUpPage, () => false);
			HistoryCommand = new Command(GotoHistoryPage, () => false);
		}
		private async void GotoHomePage()
		{					
		    await App.Current.MainPage.Navigation.PushAsync(new TabHomePage());					
		}private async void GotoTopUpPage()
		{					
		    await App.Current.MainPage.Navigation.PushAsync(new TopUpPage());					
		}private async void GotoHistoryPage()
		{					
		    await App.Current.MainPage.Navigation.PushAsync(new HistoryPage());					
		}
	}
}
