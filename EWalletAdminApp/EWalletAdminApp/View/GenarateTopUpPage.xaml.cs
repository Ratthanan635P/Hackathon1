using EWalletAdminApp.Models;
using EWalletAdminApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
//using ZXing.Net.Mobile.Forms;

namespace EWalletAdminApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GenarateTopUpPage : ContentPage
	{
		public GenarateTopUpPage(DataModel data)
		{
			InitializeComponent();

			BindingContext = new GenarateTopUpViewModel(data);
			string code = "TT0TT"+App.Email+"TT1TT"+ data.RefNo + "TT2TT" +data.ExpireDate + "TT3TT" + data.Money + "TT4TT";
			ZXingBarcodeImageView barcode = new ZXingBarcodeImageView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				AutomationId = "zxingBarcodeImageView",
			};
			barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
			barcode.BarcodeOptions.Width = 300;
			barcode.BarcodeOptions.Height = 300;
			barcode.BarcodeOptions.Margin = 10;
			barcode.BarcodeValue = code;
			TestQR.Children.Add(barcode);
		}
	}
}