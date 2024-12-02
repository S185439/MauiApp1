using MauiApp1.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
using MauiApp1.Pages;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG   
            builder.Logging.AddDebug();
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<LoginRegisterPage>();
            builder.Services.AddTransient<LoginRegisterViewModel>();
            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<DetailViewModel>();
            builder.Services.AddTransient<ReminderPage>();
            builder.Services.AddTransient<ReminderViewModel>();
            builder.Services.AddTransient<EventDetailPage>();
            builder.Services.AddTransient<EventDetailViewModel>();
            builder.Services.AddTransient<InsuranceSubscribtionPage>();
            builder.Services.AddTransient<InsuranceSubscribtionViewModel>();
            builder.Services.AddTransient<TodoPage>();
            builder.Services.AddTransient<TodoViewModel>();
            builder.Services.AddTransient<CalendarPage>();
            builder.Services.AddTransient<CalendarViewModel>();
#endif

            return builder.Build();
        }
    }
}
