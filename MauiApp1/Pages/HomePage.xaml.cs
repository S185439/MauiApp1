
using MauiApp1.ViewModels;

namespace MauiApp1
{
    public partial class HomePage : ContentPage
    {
        private readonly HomeViewModel _viewModel;
        public HomePage(HomeViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            _viewModel = vm;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadWindows();
        }
    }
}
