using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
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

        ApiClient? apiClient = services?.GetRequiredService<ApiClient>();

        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
        ApiException.ThrowIfUnauthorizedAccess(response, apiClient);
        await ApiException.ThrowIfErrorAsync(response, cancellationToken);
        return response;
    }

    #endregion Methods
}
