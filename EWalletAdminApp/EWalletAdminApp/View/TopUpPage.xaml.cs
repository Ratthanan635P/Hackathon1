using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EWalletAdminApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TopUpPage : ContentPage
	{
		public TopUpPage()
		{
			InitializeComponent();
		}

		private void Entry_Unfocused(object sender, FocusEventArgs e)
		{

		}

		private void Entry_Focused(object sender, FocusEventArgs e)
		{

		}
	}
}