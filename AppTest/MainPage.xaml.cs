using AppTest.Views;

namespace AppTest
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        //-------------------------------------------PDF Display--------------------------------------------------------------
        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new PdfGridDisplay());
        }

        //-------------------------------------------Scrollable Horizontal Calendar Display-----------------------------------
        private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new CalendarPage());
        }

        //-------------------------------------------Web View Display-----------------------------------------------------------
        private async void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new WebViewPage());
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new AbsoluteLayoutView());
        }
    }

}
