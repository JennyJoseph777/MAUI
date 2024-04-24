using AppTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CollectionView : ContentPage
	{
        CollectionViewModel _viewModel;
        public CollectionView ()
		{
			InitializeComponent ();
            BindingContext = _viewModel = new CollectionViewModel();
            _viewModel.OnAppearing();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}