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

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        Items = new ObservableCollection<string>();

        WindowDtos = new ObservableCollection<WindowDto>()
        {
            new() { Id = 0, Name = "ReminderPage"},
            new() { Id = 1, Name = "DetailPage"},
            new() { Id = 2, Name = "CalendarPage"},
            new() { Id = 3, Name = "InsuranceSubscribtionPage"},
            new() { Id = 4, Name = "EventDetailPage" },
            new() { Id = 5, Name = "ReminderPage" }
        };
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    WindowDto selectedWindow;

    [ObservableProperty]
    ObservableCollection<WindowDto> windowDtos;
    
    [ObservableProperty]
    string text;

    [RelayCommand]
    void Add()
    {
        if (SelectedWindow == null || string.IsNullOrWhiteSpace(SelectedWindow.Name))
            return;
        Items.Add(SelectedWindow.Name);
    }

    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove(s);
        }
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{s}?Text={s}");
    }
 }

