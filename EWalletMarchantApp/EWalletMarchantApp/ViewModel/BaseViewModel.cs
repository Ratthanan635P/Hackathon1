using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace EWalletMarchantApp.ViewModel
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		//public IUserService UserService { get; } = DependencyService.Get<IUserService>();
		public int LengthEmail { get; private set; }
		public int LengthPassword { get; private set; }
		public int LengthMax { get; private set; }
		public event PropertyChangedEventHandler PropertyChanged;
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
		public BaseViewModel()
		{
			LengthEmail = 4;
			LengthPassword = 6;
			LengthMax = 50;
		}
		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;
			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));

		}
		protected async void BackPage()
		{
			await App.Current.MainPage.Navigation.PopAsync();
		}
		public bool CheckRegEx_UserName(string username)
		{
			//var patterns = @"^(?=.*[a - z])(?=.*[A - Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{"+App.LengthEmail+","+App.LengthMax + "}$";
			var patterns = @"^(?=.*[A-Z])(?=.*[#$^+=!*()@%&]).{4,50}$";
			//var patterns = @"^(?=.*[A - Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{"+App.LengthEmail.ToString()+","+App.LengthMax.ToString() + "}$";
			Regex rx = new Regex(patterns, RegexOptions.IgnoreCase);
			username = username.ToUpper();
			bool isCheck = rx.IsMatch(username);
			return isCheck;
		}
		public bool CheckRegEx_Password(string password)
		{
			//var patterns= @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{" + App.LengthPassword + "," + App.LengthMax + "})";
			var patterns = @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,50})";
			Regex rx = new Regex(patterns, RegexOptions.IgnoreCase);
			//password = password;
			return rx.IsMatch(password);
		}

	}
}
