using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PdfGridDisplay : ContentPage
    {
        public PdfGridDisplay()
        {
            InitializeComponent();
        }

      

        private async void FAQ_ImageButton_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new PdfDisplayPage());

#if ANDROID
            var tapEventArgs = (ImageButton)sender;
            await Navigation.PushAsync(new PdfDisplayPage());

#else
            var tapEventArgs = (TappedEventArgs)e;
            await Navigation.PushAsync(new PdfDisplayPage());
#endif
        }
    }
}