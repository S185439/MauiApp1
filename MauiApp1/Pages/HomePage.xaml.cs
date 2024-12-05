using MauiApp1.ViewModels;

namespace MauiApp1
{
    public partial class HomePage : ContentPage
    {
        int count = 0;

        public HomePage(HomeViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }
        
        
       
    }

}
