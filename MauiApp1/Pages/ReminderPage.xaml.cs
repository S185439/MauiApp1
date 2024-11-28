using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class ReminderPage : ContentPage
{
	public ReminderPage(ReminderViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}