using SteamStorageAPI.SDK.Utilities.Exceptions;

namespace SteamStorageAPI.SDK.Utilities.DelegatingHandlers;

public class ApiExceptionHandler : DelegatingHandler
{
    #region Fields

    private readonly ApiClient _apiClient;

    #endregion Fields

    #region Constructor

    public ApiExceptionHandler(
        ApiClient apiClient)
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
        ApiException.ThrowIfUnauthorizedAccess(response, _apiClient);
        await ApiException.ThrowIfErrorAsync(response, cancellationToken);
        return response;
    }

    #endregion Methods
}
