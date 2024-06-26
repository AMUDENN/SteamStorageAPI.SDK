﻿using Microsoft.AspNetCore.SignalR.Client;
using SteamStorageAPI.SDK.ApiEntities;
using SteamStorageAPI.SDK.Utilities;

namespace SteamStorageAPI.SDK.Services.AuthorizationService;

public class AuthorizationService : IAuthorizationService
{
    #region Events

    public event IAuthorizationService.AuthorizationCompletedEventHandler? AuthorizationCompleted;
    
    public event IAuthorizationService.LogOutCompletedEventHandler? LogOutCompleted;

    #endregion Events
    
    #region Fields

    private readonly ApiClient _apiClient;

    #endregion Fields

    #region Constructor

    public AuthorizationService(
        ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    #endregion Constructor

    #region Methods

    public async void LogIn()
    {
        Authorize.AuthUrlResponse? authUrlResponse =
            await _apiClient.GetAsync<Authorize.AuthUrlResponse, Authorize.GetAuthUrlRequest>(
                ApiConstants.ApiMethods.GetAuthUrl,
                new(null));

        if (authUrlResponse is null) return;

        UrlUtility.OpenUrl(authUrlResponse.Url);

        HubConnection hubConnection = new HubConnectionBuilder()
            .WithUrl(ApiConstants.TOKEN_HUB_ENDPOINT)
            .Build();

        hubConnection.On<string>(ApiConstants.TOKEN_METHOD_NAME,
            async token =>
            {
                _apiClient.Token = token;
                await hubConnection.StopAsync();
                OnAuthorizationCompleted();
            });

        await hubConnection.StartAsync();

        await hubConnection.InvokeAsync(ApiConstants.JOIN_GROUP_METHOD_NAME, authUrlResponse.Group);
    }

    public async void LogIn(string returnTo)
    {
        Authorize.AuthUrlResponse? authUrlResponse =
            await _apiClient.GetAsync<Authorize.AuthUrlResponse, Authorize.GetAuthUrlRequest>(
                ApiConstants.ApiMethods.GetAuthUrl,
                new(returnTo));

        if (authUrlResponse is null) return;

        UrlUtility.OpenUrl(authUrlResponse.Url);
    }

    public async void LogOut()
    {
        await Task.Run(() => _apiClient.Token = string.Empty);
        OnLogOutCompleted();
    }
    
    private void OnAuthorizationCompleted()
    {
        AuthorizationCompleted?.Invoke(this);
    }
    
    private void OnLogOutCompleted()
    {
        LogOutCompleted?.Invoke(this);
    }

    #endregion Methods
}
