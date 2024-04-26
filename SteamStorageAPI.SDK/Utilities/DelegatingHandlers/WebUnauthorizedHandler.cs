using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SteamStorageAPI.SDK.Services.Logger.LoggerService;

namespace SteamStorageAPI.SDK.Utilities.DelegatingHandlers;

public class WebUnauthorizedHandler : DelegatingHandler
{
    #region Fields

    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly ILoggerService _logger;

    #endregion Fields

    #region Constructor

    public WebUnauthorizedHandler(
        IHttpContextAccessor httpContextAccessor,
        ILoggerService logger)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    #endregion Constructor

    #region Methods

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode != HttpStatusCode.Unauthorized) return response;

        IServiceProvider? services = _httpContextAccessor.HttpContext?.RequestServices;

        ApiClient? apiClient = services?.GetRequiredService<ApiClient>();

        if (apiClient is not null)
            apiClient.Token = string.Empty;
        
        await _logger.LogAsync("Unauthorized request");

        return response;
    }

    #endregion Methods
}
