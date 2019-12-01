using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EWalletMarchantApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogInPage : ContentPage
	{
		public LogInPage()
		{
			InitializeComponent();
			//ActionImage();
		}
//		private async void ActionImage()
//		{
//			await Task.WhenAll(
//				fEmail.TranslateTo(0, 100, 50, Easing.SpringIn),
//				fPassword.TranslateTo(0, 100, 50, Easing.SpringIn),
//				BtnLogIn.TranslateTo(0, 100, 50, Easing.SpringIn),				
//				Img_Logo.TranslateTo(0, 100, 50, Easing.SpringIn)
//				);
//			Img_Logo.IsVisible = true;
//			await Task.WhenAll(
//			Img_Logo.FadeTo(1, 2500),
//			 Img_Logo.TranslateTo(0, 0, 500, Easing.Linear)
//			);
//			await Task.Delay(200);
//			fEmail.IsVisible = true;
//			fPassword.IsVisible = true;
//			BtnLogIn.IsVisible = true;

//			await Task.WhenAll(
//				fEmail.TranslateTo(0, 0, 500, Easing.Linear),
//				fPassword.TranslateTo(0, 0, 500, Easing.Linear),
//				BtnLogIn.TranslateTo(0, 0, 500, Easing.Linear)
//);

//		}
	}
}