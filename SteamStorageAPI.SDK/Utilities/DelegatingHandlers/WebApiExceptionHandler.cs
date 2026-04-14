using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SteamStorageAPI.SDK.ApiClient;
using SteamStorageAPI.SDK.Utilities.Exceptions;

namespace SteamStorageAPI.SDK.Utilities.DelegatingHandlers;

public class WebApiExceptionHandler : DelegatingHandler
{
    #region Fields

    private readonly IHttpContextAccessor _httpContextAccessor;

    #endregion Fields

    #region Constructor

    public WebApiExceptionHandler(
        IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    #endregion Constructor

    #region Methods

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        IServiceProvider? services = _httpContextAccessor.HttpContext?.RequestServices;

        IApiClient? apiClient = services?.GetService<IApiClient>();

        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
        await ApiException.ThrowIfErrorAsync(response, apiClient, cancellationToken);
        return response;
    }

    #endregion Methods
}