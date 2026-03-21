using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SteamStorageAPI.SDK.ApiClient;
using SteamStorageAPI.SDK.Utilities.DelegatingHandlers;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace SteamStorageAPI.SDK.Utilities.Extensions.ServiceCollection.Api;

public static partial class ServiceCollectionExtensions
{
    #region Methods

    public static IServiceCollection AddSteamStorageApi(
        this IServiceCollection services,
        Action<ApiClientOptions>? configureOptions)
    {
        ApiClientOptions clientOptions = new();
        configureOptions?.Invoke(clientOptions);

        //Main HttpClient
        services.AddHttpClient(clientOptions.ClientName,
                client =>
                {
                    client.Timeout = TimeSpan.FromSeconds(clientOptions.ClientTimeout);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                })
            .AddHttpMessageHandler<TokenHandler>()
            .AddHttpMessageHandler<ApiExceptionHandler>();
        //TokenHandler
        services.AddTransient<TokenHandler>();
        //UnauthorizedHandler
        services.AddTransient<ApiExceptionHandler>();
        //ApiClient
        services.AddSingleton<IApiClient, ApiClient.ApiClient>(x => 
            new ApiClient.ApiClient(
                x.GetService<ILogger<IApiClient>>(),
                x.GetRequiredService<IHttpClientFactory>(),
                clientOptions.ClientName,
                clientOptions.HostName,
                clientOptions.ServerAddress,
                clientOptions.ApiAddress,
                clientOptions.TokenHubEndpoint));

        return services;
    }

    public static IServiceCollection AddSteamStorageApiWeb(
        this IServiceCollection services,
        Action<ApiClientOptions>? configureOptions)
    {
        ApiClientOptions clientOptions = new();
        configureOptions?.Invoke(clientOptions);

        //HttpContextAccessor
        services.AddHttpContextAccessor();

        //Main HttpClient
        services.AddHttpClient(clientOptions.ClientName,
                client =>
                {
                    client.Timeout = TimeSpan.FromSeconds(clientOptions.ClientTimeout);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                })
            .AddHttpMessageHandler<WebTokenHandler>()
            .AddHttpMessageHandler<WebApiExceptionHandler>();
        //TokenHandler
        services.AddTransient<WebTokenHandler>();
        //UnauthorizedHandler
        services.AddTransient<WebApiExceptionHandler>();
        //ApiClient
        services.AddScoped<IApiClient, ApiClient.ApiClient>(x => 
            new ApiClient.ApiClient(
                x.GetService<ILogger<IApiClient>>(),
                x.GetRequiredService<IHttpClientFactory>(),
                clientOptions.ClientName,
                clientOptions.HostName,
                clientOptions.ServerAddress,
                clientOptions.ApiAddress,
                clientOptions.TokenHubEndpoint));

        return services;
    }

    #endregion Methods
}