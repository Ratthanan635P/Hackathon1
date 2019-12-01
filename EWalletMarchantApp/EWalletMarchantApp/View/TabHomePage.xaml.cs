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
	public partial class TabHomePage : TabbedPage
	{
		public TabHomePage()
		{
			InitializeComponent();
		}
	}
}