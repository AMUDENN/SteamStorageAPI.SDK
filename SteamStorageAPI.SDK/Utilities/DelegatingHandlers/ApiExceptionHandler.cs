using SteamStorageAPI.SDK.ApiClient;
using SteamStorageAPI.SDK.Utilities.Exceptions;

namespace SteamStorageAPI.SDK.Utilities.DelegatingHandlers;

public class ApiExceptionHandler : DelegatingHandler
{
    #region Fields

    private readonly IApiClient _apiClient;

    #endregion Fields

    #region Constructor

    public ApiExceptionHandler(
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
        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
        await ApiException.ThrowIfErrorAsync(response, _apiClient, cancellationToken);
        return response;
    }

    #endregion Methods
}