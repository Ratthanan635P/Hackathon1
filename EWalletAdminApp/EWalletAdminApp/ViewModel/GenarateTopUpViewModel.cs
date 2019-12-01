using Android.Content.Res;
using EWalletAdminApp.Models;
using EWalletAdminApp.View.PopUp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EWalletAdminApp.ViewModel
{
	public class GenarateTopUpViewModel :BaseViewModel
	{

		private double money;
		public double Money
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
		private string refNo;
		public string RefNo
		{
			get { return refNo; }
			set
			{
				if (value != refNo)
				{
					refNo = value;
					OnPropertyChanged();
				}
			}
		}
		private DateTime expire;
		public DateTime Expire
		{
			get { return expire; }
			set
			{
				if (value != expire)
				{
					expire = value;
					OnPropertyChanged();
				}
			}
		}
		public ICommand CommitCommand { get; set; }
		public GenarateTopUpViewModel(DataModel data)
		{
			Money = data.Money;
			RefNo = data.RefNo;
			Expire = data.ExpireDate;
			CommitCommand = new Command(GotoGenaratePage);
		}
		private async void GotoGenaratePage()
		{
			//await PopupNavigation.Instance.PushAsync(new HistoryPopUpPage());
			var maxpage = App.Current.MainPage.Navigation.NavigationStack.Count;
			App.Current.MainPage.Navigation.RemovePage(App.Current.MainPage.Navigation.NavigationStack[maxpage-1]);
			await App.Current.MainPage.Navigation.PopAsync();
		}
	}

}
