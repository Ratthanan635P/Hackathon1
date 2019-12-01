using EWalletAdminApp.Models;
using EWalletAdminApp.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

			GenTopUpModel topUpModel = new GenTopUpModel() 
            { 
				Money =Convert.ToDouble(Money),
				AgrentId=App.Email
             };
			Uri url = new Uri(App.BaseUri, "Agrent/Topup"); //Agrent
			try
			{
		HttpResponseMessage result;
				string json = JsonConvert.SerializeObject(topUpModel);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
				using (HttpClient client = new HttpClient())
				{
					result = await client.PostAsync(url, content);
				}
				if (result.IsSuccessStatusCode)
				{
					//Navigate to Home page
					var stringContent = await result.Content.ReadAsStringAsync();
					//App.UserId = 1;
					var data = JsonConvert.DeserializeObject<DataModel>(stringContent);
					await App.Current.MainPage.Navigation.PushAsync(new GenarateTopUpPage(data));
					ErrorMessage = null;
				}
				else
				{
					//	ErrorMessage= await result.Content.ReadAsStringAsync();
					ErrorMessage = "Email or Password is wrong!";
				}
				Loading = false;
			}
			catch (Exception ex)
			{
				Loading = false;
				ErrorMessage = ex.Message;
			}
			
		}
		private async void BacknPage()
		{
			await App.Current.MainPage.Navigation.PopAsync();
		}
	}
}
