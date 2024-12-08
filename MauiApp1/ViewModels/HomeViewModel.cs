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
using System.Net.Http.Json;

namespace MauiApp1.ViewModels;

[QueryProperty(nameof(User), "User")]
public partial class HomeViewModel : ObservableObject
{
    HttpClient _httpClient;
    public HomeViewModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
        Items = new ObservableCollection<WindowDto>();

        WindowDtos = new ObservableCollection<WindowDto>()
        {
            new() { PageName = "ReminderPage"},
            new() { PageName = "LoginRegisterPage"},
            new() { PageName = "CalendarPage"},
            new() { PageName = "InsuranceSubscribtionPage"},
            new() { PageName = "EventDetailPage" },
            new() { PageName = "ReminderPage" },
            new() { PageName = "TodoPage" }
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
    async Task Add()
    {
        Console.WriteLine(User.Name);
        if (SelectedWindow == null || string.IsNullOrWhiteSpace(SelectedWindow.PageName))
            return;
        WindowDto window = new WindowDto { Id = Guid.NewGuid(), PageName = SelectedWindow.PageName, Title = PageTitle  };
        try
        {
            await _httpClient.PostAsJsonAsync($"http://localhost:5001/users/{User.Id}/windows", window);
            Items.Add(window);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    [RelayCommand]
    async Task Delete(WindowDto window)
    {
        try
        {
            await _httpClient.DeleteAsync($"http://localhost:5001/users/{User.Id}/windows/{window.Id}");
            Items.Remove(window);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    [RelayCommand]
    async Task Tap(WindowDto window)
    {
        await Shell.Current.GoToAsync($"{window.PageName}");
    }

    public async Task LoadWindows()
    {
        try
        {
            var windows = await _httpClient.GetFromJsonAsync<List<WindowDto>>($"http://localhost:5001/users/{User.Id}/windows");
            if (windows != null)
            {
                Items.Clear();
                foreach (var window in windows)
                {
                    Items.Add(window);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
 }

