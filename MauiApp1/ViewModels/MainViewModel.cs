using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        Items = new ObservableCollection<string>();

        PageNames = new ObservableCollection<string>()
        {
            "DetailPage",
            "ReminderPage"
        };
    }
    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    ObservableCollection<string> pageNames;
    
    [ObservableProperty]
    string text;

    [RelayCommand]
    void Add()
    {   
        if (string.IsNullOrWhiteSpace(Text))
            return;
        Items.Add(Text);
        Text = string.Empty;
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

