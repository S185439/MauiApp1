using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.DataObjects;

namespace MauiApp1.ViewModels;

[QueryProperty(nameof(User), "User")]
public partial class HomeViewModel : ObservableObject
{
    public HomeViewModel()
    {
        Items = new ObservableCollection<WindowDto>();

        WindowDtos = new ObservableCollection<WindowDto>()
        {
            new() { PageName = "ReminderPage"},
            new() { PageName = "LoginRegisterPage"},
            new() { PageName = "CalendarPage"},
            new() { PageName = "InsuranceSubscribtionPage"},
            new() { PageName = "EventDetailPage" },
            new() { PageName = "ReminderPage" }
        };
    }

    [ObservableProperty]
    UserDto user;

    [ObservableProperty]
    ObservableCollection<WindowDto> items;

    [ObservableProperty]
    WindowDto selectedWindow;

    [ObservableProperty]
    ObservableCollection<WindowDto> windowDtos;
    
    [ObservableProperty]
    string pageTitle;

    [RelayCommand]
    void Add()
    {
        Console.WriteLine(User.Name);
        if (SelectedWindow == null || string.IsNullOrWhiteSpace(SelectedWindow.PageName))
            return;
        WindowDto window = new WindowDto { Id = Guid.NewGuid(), PageName = SelectedWindow.PageName, Title = PageTitle  };
        Items.Add(window);
    }

    [RelayCommand]
    void Delete(WindowDto window)
    {
        if (Items.Contains(window))
        {
            Items.Remove(window);
        }
    }

    [RelayCommand]
    async Task Tap(WindowDto window)
    {
        await Shell.Current.GoToAsync($"{window.PageName}");

    }
 }

