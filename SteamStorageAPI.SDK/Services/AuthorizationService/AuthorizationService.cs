using Microsoft.AspNetCore.SignalR.Client;
using SteamStorageAPI.SDK.ApiClient;
using SteamStorageAPI.SDK.ApiEntities;
using SteamStorageAPI.SDK.Utilities.ApiControllers;
using SteamStorageAPI.SDK.Utilities.UrlUtility;

namespace SteamStorageAPI.SDK.Services.AuthorizationService;

public class AuthorizationService : IAuthorizationService
{
    #region Fields

    private readonly IApiClient _apiClient;

    private readonly TimeSpan _connectionTimeout;

    #endregion Fields

    #region Constructor

    public AuthorizationService(
        IApiClient apiClient,
        TimeSpan  connectionTimeout)
    {
        _apiClient = apiClient;
        _connectionTimeout = connectionTimeout;
    }

    #endregion Constructor

    #region Events

    public event IAuthorizationService.AuthorizationCompletedEventHandler? AuthorizationCompleted;

    public event IAuthorizationService.LogOutCompletedEventHandler? LogOutCompleted;

    #endregion Events

    #region Methods

    public async Task LogInAsync(CancellationToken cancellationToken = default)
    {
        Authorize.AuthUrlResponse? authUrlResponse =
            await _apiClient.GetAsync<Authorize.AuthUrlResponse, Authorize.GetAuthUrlRequest>(
                ApiConstants.ApiMethods.GetAuthUrl,
                new Authorize.GetAuthUrlRequest(null),
                cancellationToken);

        if (authUrlResponse is null) return;

        UrlUtility.OpenUrl(authUrlResponse.Url);

        HubConnection hubConnection = new HubConnectionBuilder()
            .WithUrl(_apiClient.TokenHubEndpoint)
            .Build();

        TaskCompletionSource<string> tokenSource = new(TaskCreationOptions.RunContinuationsAsynchronously);
        
        using CancellationTokenSource timeoutCts = new(_connectionTimeout);
        
        using CancellationTokenSource linkedCts = 
            CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);
        
        CancellationToken linkedToken = linkedCts.Token;
        
        await using CancellationTokenRegistration ctr = 
            linkedCts.Token.Register(() => tokenSource.TrySetCanceled(linkedToken));

        try
        {
            hubConnection.On<string>(ApiConstants.TOKEN_METHOD_NAME,
                token => tokenSource.TrySetResult(token));

            await hubConnection.StartAsync(linkedCts.Token);
            await hubConnection.InvokeAsync(ApiConstants.JOIN_GROUP_METHOD_NAME,
                authUrlResponse.Group, linkedCts.Token);

            string token = await tokenSource.Task;

            _apiClient.Token = token;
            OnAuthorizationCompleted();
        }
        finally
        {
            await hubConnection.DisposeAsync();
        }
    }

    public async Task LogInAsync(string returnTo, CancellationToken cancellationToken = default)
    {
        Authorize.AuthUrlResponse? authUrlResponse =
            await _apiClient.GetAsync<Authorize.AuthUrlResponse, Authorize.GetAuthUrlRequest>(
                ApiConstants.ApiMethods.GetAuthUrl,
                new Authorize.GetAuthUrlRequest(returnTo),
                cancellationToken);

        if (authUrlResponse is null) return;

        UrlUtility.OpenUrl(authUrlResponse.Url);
    }

    public Task LogOutAsync(CancellationToken cancellationToken = default)
    {
        _apiClient.Token = null;
        OnLogOutCompleted();
        return Task.CompletedTask;
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