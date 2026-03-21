using Microsoft.Extensions.DependencyInjection;
using SteamStorageAPI.SDK.ApiClient;
using SteamStorageAPI.SDK.Services.AuthorizationService;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace SteamStorageAPI.SDK.Utilities.Extensions.ServiceCollection.Authorization;

public static partial class ServiceCollectionExtensions
{
    #region Methods

    public static IServiceCollection AddSteamStorageAuthorizationService(
        this IServiceCollection services,
        Action<AuthorizationServiceOptions>? configureOptions)
    {
        AuthorizationServiceOptions options = new();
        configureOptions?.Invoke(options);
        
        //AuthorizationService
        services.AddScoped<IAuthorizationService, AuthorizationService>(x =>
            new AuthorizationService(
                x.GetRequiredService<IApiClient>(),
                options.TokenHubTimeout));

        return services;
    }
    
    #endregion Methods
}