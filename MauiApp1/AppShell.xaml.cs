using MauiApp1.Pages;

namespace MauiApp1;
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(LoginRegisterPage), typeof(LoginRegisterPage));
        Routing.RegisterRoute(nameof(ReminderPage), typeof(ReminderPage));
        Routing.RegisterRoute(nameof(CalendarPage), typeof(CalendarPage));
        Routing.RegisterRoute(nameof(EventDetailPage), typeof(EventDetailPage));
        Routing.RegisterRoute(nameof(InsuranceSubscribtionPage), typeof(InsuranceSubscribtionPage));
        Routing.RegisterRoute(nameof(TodoPage), typeof(TodoPage));
    }
}
