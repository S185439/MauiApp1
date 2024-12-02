using MauiApp1.ViewModels;

namespace MauiApp1.Pages;

public partial class LoginRegisterPage : ContentPage
{
	public LoginRegisterPage(LoginRegisterViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}