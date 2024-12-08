using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Maui.Calendar.Models;
using MauiApp1.DataObjects;

namespace MauiApp1.ViewModels;

public partial class CalendarViewModel : ObservableObject
{
    public CalendarViewModel()
    {
        Events = new EventCollection();
    }

    public EventCollection Events { get; set; }

    [ObservableProperty]
    DateTime selectedDate;

    [ObservableProperty]
    string eventTitle;

    [RelayCommand]
    void AddEvent()
    {
        var newEvent = new EventDto
        {
            Title = EventTitle,
            Description = "Description",
            StartDate = SelectedDate,
            EndDate = SelectedDate,
            Location = "Location"
        };

        if (Events.ContainsKey(SelectedDate))
        {
            var eventList = Events[SelectedDate] as List<EventDto>;
            if (eventList != null)
            {
                eventList.Add(newEvent);
            }
        }
        else
        {
            Events[SelectedDate] = new List<EventDto> { newEvent };
        }
    }
       
}
