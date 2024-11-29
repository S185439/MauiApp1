using MauiApp1.ViewModels;

namespace MauiApp1.Pages;

public partial class EventDetailPage : ContentPage
{
	public EventDetailPage(EventDetailViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}