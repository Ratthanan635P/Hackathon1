using EWalletAdminApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EWalletAdminApp.ViewModel
{
	 public class TopUpPageViewModel
	{
		public ICommand CommitCommand { get; set; }
		public ICommand BackPageCommand { get; set; }
		public string Money { get; set; }
		public TopUpPageViewModel()
		{
			CommitCommand = new Command(GotoGenaratePage);
			BackPageCommand = new Command(BackPage);
		}
		private async void GotoGenaratePage()
		{
			await App.Current.MainPage.Navigation.PushAsync(new GenarateTopUpPage());
		}
		private async void BackPage()
		{
			await App.Current.MainPage.Navigation.PopAsync();
		}
	}
}
