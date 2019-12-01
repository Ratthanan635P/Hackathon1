using EWalletAdminApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EWalletAdminApp.ViewModel
{
	 public class TopUpPageViewModel:BaseViewModel
	{
		public ICommand CommitCommand { get; set; }
		public ICommand BackPageCommand { get; set; }
		//public string Money { get; set; }
		private string money;
		public string Money
		{
			get { return money; }
			set
			{
				if (value != money)
				{
					money = value;
					OnPropertyChanged();
				}
			}
		}
		public TopUpPageViewModel()
		{
			
			CommitCommand = new Command(GotoGenaratePage);
			BackPageCommand = new Command(BacknPage);
		}
		private async void GotoGenaratePage()
		{
			await App.Current.MainPage.Navigation.PushAsync(new GenarateTopUpPage());
		}
		private async void BacknPage()
		{
			await App.Current.MainPage.Navigation.PopAsync();
		}
	}
}
