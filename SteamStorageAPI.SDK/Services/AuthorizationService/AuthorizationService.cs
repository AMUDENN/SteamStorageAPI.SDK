using Microsoft.AspNetCore.SignalR.Client;
using SteamStorageAPI.SDK.ApiEntities;
using SteamStorageAPI.SDK.Utilities;

namespace SteamStorageAPI.SDK.Services.AuthorizationService;

public class AuthorizationService : IAuthorizationService
{
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
        await LogInAsync();
    }

    public async Task LogInAsync()
    {
        Authorize.AuthUrlResponse? authUrlResponse =
            await _apiClient.GetAsync<Authorize.AuthUrlResponse>(
                ApiConstants.ApiMethods.GetAuthUrl);

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
            });

        await hubConnection.StartAsync();

        await hubConnection.InvokeAsync(ApiConstants.JOIN_GROUP_METHOD_NAME, authUrlResponse.Group);
    }

    public async void LogOut()
    {
        await LogOutAsync();
    }

    public async Task LogOutAsync()
    {
        await Task.Run(() => _apiClient.Token = string.Empty);
    }

    #endregion Methods
}
