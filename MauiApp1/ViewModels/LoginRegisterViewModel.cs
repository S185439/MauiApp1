using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using PlannerAPI.Model;

[QueryProperty("Text", "Text")]
public partial class LoginRegisterViewModel : ObservableObject
{
    private readonly HttpClient _httpClient;

    public LoginRegisterViewModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
        Text = string.Empty;
        Username = string.Empty;
        Password = string.Empty;
        EntryEmail = string.Empty;
    }

    [ObservableProperty]
    string text;

    [ObservableProperty]
    string username;

    [ObservableProperty]
    string password;

    [ObservableProperty]
    string entryEmail;

    [RelayCommand]
    async Task Login()
    {
        if (!string.IsNullOrWhiteSpace(EntryEmail) || !string.IsNullOrWhiteSpace(Password))
        {
            try
            {
                var user = await _httpClient.GetFromJsonAsync<User>($"users/username/{Username}");
                if (user == null)
                {
                    Console.WriteLine("User not found");
                    return;
                }
                if (user.Password != Password)
                {
                    Console.WriteLine("Invalid password");
                    return;
                }
                await Shell.Current.GoToAsync("MainPage");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //If the user is not valid
        //Show an error message
    }

    [RelayCommand]
    async Task Register()
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("users", new User { Name = Username, Password = Password, Email = EntryEmail });
            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                Console.WriteLine("User already exists");
                return;
            }
            await Shell.Current.GoToAsync("MainPage");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        //If the user is already registered
        //Show an error message
    }

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}

