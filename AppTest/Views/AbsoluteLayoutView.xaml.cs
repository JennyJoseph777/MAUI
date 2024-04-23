using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AbsoluteLayoutView : ContentPage
	{
		public AbsoluteLayoutView ()
		{
			InitializeComponent ();
		}

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            Uri uri = new Uri("https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui?view=net-maui-8.0");
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}