using MauiApp1.ViewModels;

namespace MauiApp1.Pages;

public partial class TodoPage : ContentPage
{
	public TodoPage(TodoViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}