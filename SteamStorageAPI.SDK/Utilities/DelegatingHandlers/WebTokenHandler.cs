using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SteamStorageAPI.SDK.ApiClient;

namespace SteamStorageAPI.SDK.Utilities.DelegatingHandlers;

public class WebTokenHandler : DelegatingHandler
{
    #region Fields

    private readonly IHttpContextAccessor _httpContextAccessor;

    #endregion Fields

    #region Constructor

    public WebTokenHandler(
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
        IApiClient? apiClient = _httpContextAccessor.HttpContext?.RequestServices.GetRequiredService<IApiClient>();

        if (!string.IsNullOrEmpty(apiClient?.Token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiClient.Token);

        return await base.SendAsync(request, cancellationToken);
    }

    #endregion Methods
}