using MauiApp1.ViewModels;

namespace MauiApp1.Pages;

public partial class InsuranceSubscribtionPage : ContentPage
{
	public InsuranceSubscribtionPage(InsuranceSubscribtionViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}