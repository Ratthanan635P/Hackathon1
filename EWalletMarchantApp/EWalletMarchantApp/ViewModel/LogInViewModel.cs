using EWalletMarchantApp.Models;
using EWalletMarchantApp.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EWalletMarchantApp.ViewModel
{
	public class LogInViewModel : BaseViewModel
	{
		private LogInModel logInModel;
		public LogInModel LogInModel
		{
			get { return logInModel; }
			set
			{
				if (value != logInModel)
				{
					logInModel = value;
					OnPropertyChanged();
				}
			}
		}		
		public ICommand LogInCommand { get; set; }
		public LogInViewModel()
		{
			logInModel = new LogInModel();
			ErrorMessage = "";
			Loading = false;
			//ForgotCommand = new Command(GotoForgotPage);
			//RegisterCommand = new Command(GotoRegisterPage);
			LogInCommand = new Command(GotoHomePage, () => true);
		}
		private async void GotoHomePage()
		{
			Loading = true;
			ErrorMessage = null;
			logInModel.Email = "test05@tt.tt";
			logInModel.Password = "Gg123456789";
			if (string.IsNullOrEmpty(logInModel.Email))//&& IsValidate Email Format
			{
				ErrorMessage = "Please Enter your email";
			}

			if (string.IsNullOrEmpty(logInModel.Password))//&& IsValidate Email Format
			{
				ErrorMessage = "Please Enter your password";
			}
			if (ErrorMessage == null)
			{
				Uri url = new Uri(App.BaseUri, "Agrent/Login"); //Agrent
			   LogInModel loginCommand = new LogInModel()
				{
					Email = logInModel.Email,
					Password = logInModel.Password
				};
				AuthenticateModel authenticateModel = new AuthenticateModel()
				{
					Email = logInModel.Email,
					Password = logInModel.Password
				};


				string json = JsonConvert.SerializeObject(authenticateModel);

				try
				{
					HttpResponseMessage result;
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
						
						var data = JsonConvert.DeserializeObject<DataAgrentModel>(stringContent);
						App.Email = logInModel.Email;
						App.UserId = data.Id;
						await App.Current.MainPage.Navigation.PushAsync(new TabHomePage());
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
		}
	}
}
