using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EWalletAdminApp.ViewModel
{
	public class HistoryPopUpPageViewModel:BaseViewModel
	{
		public ICommand BackPageCommand { get; set; }
		public HistoryPopUpPageViewModel()
		{
			BackPageCommand = new Command(BacknPage);
		}
		private async void BacknPage()
		{
			await PopupNavigation.Instance.PopAsync();
		}
	}
}
