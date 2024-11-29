using MauiApp1.ViewModels;

namespace MauiApp1.Pages;

public partial class CalendarPage : ContentPage
{
	public CalendarPage(CalendarViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
    }
}