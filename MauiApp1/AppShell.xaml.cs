using MauiApp1.Pages;

namespace MauiApp1;
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        Routing.RegisterRoute(nameof(ReminderPage), typeof(ReminderPage));
        Routing.RegisterRoute(nameof(CalendarPage), typeof(CalendarPage));
        Routing.RegisterRoute(nameof(EventDetailPage), typeof(EventDetailPage));
        Routing.RegisterRoute(nameof(InsuranceSubscribtionPage), typeof(InsuranceSubscribtionPage));
        Routing.RegisterRoute(nameof(TodoPage), typeof(TodoPage));
        Routing.RegisterRoute(nameof(LoginRegisterPage), typeof(LoginRegisterPage));
    }
}
