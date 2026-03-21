using System.Net.Http.Headers;
using SteamStorageAPI.SDK.ApiClient;

namespace SteamStorageAPI.SDK.Utilities.DelegatingHandlers;

public class TokenHandler : DelegatingHandler
{
    #region Fields

    private readonly IApiClient _apiClient;

    #endregion Fields

    #region Constructor

    public TokenHandler(
        IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    #endregion Constructor

    #region Methods

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(_apiClient.Token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiClient.Token);

        return await base.SendAsync(request, cancellationToken);
    }

    #endregion Methods
}