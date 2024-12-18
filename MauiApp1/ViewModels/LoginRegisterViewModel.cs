﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.DataObjects;
using System.Net.Http.Json;

namespace MauiApp1.ViewModels;

public partial class LoginRegisterViewModel : ObservableObject
{
    private readonly HttpClient _httpClient;

    public LoginRegisterViewModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
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
                var user = await _httpClient.GetFromJsonAsync<UserDto>($"http://localhost:5001/users/username/{Username}");
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
                var loggedInUser = new Dictionary<string, object> { { "User", user } };
                await Shell.Current.GoToAsync("HomePage", loggedInUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    [RelayCommand]
    async Task Register()
    {
        try
        {
            var user = new UserDto { Id = Guid.NewGuid(), Name = Username, Password = Password, Email = EntryEmail };
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5001/users") { Content = JsonContent.Create(user) };
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                Console.WriteLine("User already exists");
                return;
            }
            var loggedInUser = new Dictionary<string, object> { { "User", user } };
            await Shell.Current.GoToAsync("HomePage", loggedInUser);
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
