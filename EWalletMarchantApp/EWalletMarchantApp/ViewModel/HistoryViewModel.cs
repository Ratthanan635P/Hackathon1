using EWalletMarchantApp.Models;
using EWalletMarchantApp.View;
using EWalletMarchantApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EWalletMarchantApp.ViewModel
{
	public class HistoryViewModel:BaseViewModel
	{
		//public List<TransationDto> Transations { get; set; }
		//public List<TransationDto> Transations { get; set; }
		private List<TransationDto> transations;
		public List<TransationDto> Transations
		{
			get { return transations; }
			set
			{
				if (value != transations)
				{
					transations = value;
					OnPropertyChanged();
				}
			}
		}
		public HistoryViewModel()
		{
			//HomeCommand = new Command(GotoHomePage, () => false);
			//TopUpCommand = new Command(GotoTopUpPage, () => false);
			//HistoryCommand = new Command(GotoHistoryPage, () => false);
			GetDataHistory();

		}
		private async void GetDataHistory()
		{
			//Loading = true;
			//ErrorMessage = null;



			//Uri url = new Uri(App.BaseUri, "Agrent/History"); //Agrent
			//try
			//	{
			//		HttpResponseMessage result;
			//		HttpContent content = new StringContent(App.Email, Encoding.UTF8, "application/json");
			//		using (HttpClient client = new HttpClient())
			//		{
			//			result = await client.PostAsync(url, content);
			//		}
			//		if (result.IsSuccessStatusCode)
			//		{
			//			//Navigate to Home page
			//			var stringContent = await result.Content.ReadAsStringAsync();
			//			//App.UserId = 1;
			//			var data = JsonConvert.DeserializeObject<TransationDto>(stringContent);					
			     await App.Current.MainPage.Navigation.PushAsync(new TopUpPage());
			//			ErrorMessage = null;
			//		}
			//		else
			//		{
			//			//	ErrorMessage= await result.Content.ReadAsStringAsync();
			//			ErrorMessage = "Email or Password is wrong!";
			//		}
			//		Loading = false;
			//	}
			//	catch (Exception ex)
			//	{
			//		Loading = false;
			//		ErrorMessage = ex.Message;
			//	}
			
		}
	}
}
