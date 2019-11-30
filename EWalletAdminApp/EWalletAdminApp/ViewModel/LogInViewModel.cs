using EWalletAdminApp.Models;
using EWalletAdminApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EWalletAdminApp.ViewModel
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
		private string errorMessage;
		public string ErrorMessage
		{
			get { return errorMessage; }
			set
			{
				if (value != errorMessage)
				{
					errorMessage = value;
					OnPropertyChanged();
				}
			}
		}
		private bool loading;
		public bool Loading
		{
			get { return loading; }
			set
			{
				if (value != loading)
				{
					loading = value;
					OnPropertyChanged();
				}
			}
		}
		public ICommand LogInCommand { get; set; }
		public LogInViewModel()
		{
			//logInModel = new LogInModel();
			//ErrorMessage = "";
			//Loading = false;
			//ForgotCommand = new Command(GotoForgotPage);
			//RegisterCommand = new Command(GotoRegisterPage);
			LogInCommand = new Command(GotoHomePage, () => true);
		}
		private async void GotoHomePage()
		{
			//Loading = true;
			//ErrorMessage = "";
			//string error = "";
			//if (!((CheckRegEx_UserName(LogInModel.Email)) && (LogInModel.Email.Length > LengthEmail)))
			//{
			//	error = " Email is Invalid!";

			//}
			//if (!((CheckRegEx_Password(LogInModel.Password)) && (LogInModel.Password.Length > LengthPassword)))
			//{
			//	if (error != "")
			//	{
			//		error = " Email and Password is Invalid! ";
			//	}
			//	else
			//	{
			//		error = " Password is Invalid!";
			//	}
			//}

			////Call Api Check email and Password

			//if (error == "")
			//{
			//	//var result = UserService.LogInUser(LogInModel);
			//	//if (result.StatusRespond == "200")
			//	//{
			//	//	ErrorMessage = "";
			//	//	//await Task.Delay(3000);
			//	//	Loading = false;
			//	//	//DataUserModel dataUser = new DataUserModel()
			//	//	//{
			//	//	//	Id = result.UserId,
			//	//	//	Email = LogInModel.Email,
			//	//	//	Password = LogInModel.PassWord
			//	//	//};
			await App.Current.MainPage.Navigation.PushAsync(new TabHomePage());
			//	//}
			//	//else
			//	//{
			//	//	//await Task.Delay(3000);
			//	//	error = result.ErrorMessage;
			//	//	ErrorMessage = error;
			//	//	Loading = false;
			//	//}
			//}
			//else
			//{
			//	//await Task.Delay(1500);
			//	ErrorMessage = error;
			//	Loading = false;
			//}
			////	await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
		}
	}
}
