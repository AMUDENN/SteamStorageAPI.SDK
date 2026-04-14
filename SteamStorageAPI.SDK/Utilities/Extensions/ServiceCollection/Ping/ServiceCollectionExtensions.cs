using Microsoft.Extensions.DependencyInjection;
using SteamStorageAPI.SDK.ApiClient;
using SteamStorageAPI.SDK.Services.PingService;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace SteamStorageAPI.SDK.Utilities.Extensions.ServiceCollection.Ping;

public static class ServiceCollectionExtensions
{
    #region Methods

    public static IServiceCollection AddSteamStoragePingService(
        this IServiceCollection services,
        Action<PingServiceOptions>? configureOptions)
    {
        PingServiceOptions options = new();
        configureOptions?.Invoke(options);

        //PingService
        services.AddScoped<IPingService, PingService>(x =>
            new PingService(
                x.GetRequiredService<IApiClient>(),
                options.PingTimeout));

        return services;
    }

    #endregion Methods
}