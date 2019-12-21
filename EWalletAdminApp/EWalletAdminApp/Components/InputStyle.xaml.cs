using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EWalletAdminApp.Components
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InputStyle : ContentView
	{
		public InputStyle()
		{
			InitializeComponent();
		}
		public static readonly BindableProperty TextLabelProperty =
						BindableProperty.Create(nameof(TextLabel),
												typeof(string),
												typeof(InputStyle),
												default(string), defaultBindingMode: BindingMode.TwoWay);
		public string TextLabel
		{
			get { return (string)GetValue(TextLabelProperty); }
			set { SetValue(TextLabelProperty, value); }
		}
		public static readonly BindableProperty TextLabelDateProperty =
						BindableProperty.Create(nameof(TextLabelDate),
												typeof(string),
												typeof(InputStyle),
												default(string), defaultBindingMode: BindingMode.TwoWay);
		public string TextLabelDate
		{
			get { return (string)GetValue(TextLabelDateProperty); }
			set { SetValue(TextLabelDateProperty, value); }
		}
		public static readonly BindableProperty TextEntryProperty =
							  BindableProperty.Create(nameof(TextEntry),
													  typeof(string),
													  typeof(InputStyle),
													  default(string), defaultBindingMode: BindingMode.TwoWay);
		public string TextEntry
		{
			get { return (string)GetValue(TextEntryProperty); }
			set { SetValue(TextEntryProperty, value); }
		}		
		public static readonly BindableProperty PasswordEntryProperty =
							  BindableProperty.Create(nameof(PasswordEntry),
													  typeof(bool),
													  typeof(InputStyle),
													  default(bool));
		public bool PasswordEntry
		{
			get { return (bool)GetValue(PasswordEntryProperty); }
			set { SetValue(PasswordEntryProperty, value); }
		}
		public static readonly BindableProperty PlacehoderProperty =
							  BindableProperty.Create(nameof(Placehoder),
													  typeof(string),
													  typeof(InputStyle),
													  default(string));
		public string Placehoder
		{
			get { return (string)GetValue(PlacehoderProperty); }
			set { SetValue(PlacehoderProperty, value); }
		}
	}
}