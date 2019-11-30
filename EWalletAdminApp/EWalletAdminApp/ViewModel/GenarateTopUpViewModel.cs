using EWalletAdminApp.View.PopUp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EWalletAdminApp.ViewModel
{
	public class GenarateTopUpViewModel 
	{
		public ICommand CommitCommand { get; set; }
		public GenarateTopUpViewModel()
		{
			CommitCommand = new Command(GotoGenaratePage);
		}
		private async void GotoGenaratePage()
		{
			await PopupNavigation.Instance.PushAsync(new HistoryPopUpPage());
		}
	}

}
