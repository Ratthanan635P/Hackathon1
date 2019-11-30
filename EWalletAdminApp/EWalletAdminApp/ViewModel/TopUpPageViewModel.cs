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
		public TopUpPageViewModel()
		{
			CommitCommand = new Command(GotoGenaratePage);
		}
		private async void GotoGenaratePage()
		{
			await App.Current.MainPage.Navigation.PushAsync(new GenarateTopUpPage());
		}
	}
}
