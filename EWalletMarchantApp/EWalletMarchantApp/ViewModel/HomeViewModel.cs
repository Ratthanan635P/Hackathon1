using EWalletMarchantApp.Functions;
using EWalletMarchantApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EWalletMarchantApp.ViewModel
{
	public class HomeViewModel:BaseViewModel
	{
		private string hello;
		public string Hello
		{
			get { return hello; }
			set
			{
				if (value != hello)
				{
					hello = value;
					OnPropertyChanged();
				}
			}
		}
		private string nameOwer;
		public string NameOwer
		{
			get { return nameOwer; }
			set
			{
				if (value != nameOwer)
				{
					nameOwer = value;
					OnPropertyChanged();
				}
			}
		}
		public ICommand TopUpCommand { get; set; }
		public ICommand HomeCommand { get; set; }
		public ICommand HistoryCommand { get; set; }
		public HomeViewModel()
		{
			HomeCommand = new Command(GotoHomePage, () => true);
			TopUpCommand = new Command(GotoTopUpPage, () => true);
			HistoryCommand = new Command(GotoHistoryPage, () => true);
			TimeHello timeHello = new TimeHello();
			Hello = timeHello.HelloAgrent;
			NameOwer = "ยินดีต้อนรับ " +App.NameShop;
		}
		private async void GotoHomePage()
		{					
		    await App.Current.MainPage.Navigation.PushAsync(new TabHomePage());					
		}
       private async void GotoTopUpPage()
		{					
		    await App.Current.MainPage.Navigation.PushAsync(new TopUpPage());					
		}
        private async void GotoHistoryPage()
		{					
		    await App.Current.MainPage.Navigation.PushAsync(new HistoryPage());					
		}
	}
}
