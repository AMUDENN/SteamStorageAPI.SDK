using Microsoft.Extensions.DependencyInjection;
using SteamStorageAPI.SDK.Services.AuthorizationService;
using SteamStorageAPI.SDK.Services.Logger.LoggerService;
using SteamStorageAPI.SDK.Services.Ping.PingService;
using SteamStorageAPI.SDK.Services.ReferenceInformationService;
using SteamStorageAPI.SDK.Utilities.DelegatingHandlers;
using SteamStorageAPI.SDK.Utilities.Extensions.ServiceCollection.Options;
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace SteamStorageAPI.SDK.Utilities.Extensions.ServiceCollection;

public static class ServiceCollectionExtensions
{
    #region Methods

    public static IServiceCollection AddSteamStorageApi(
        this IServiceCollection services,
        Action<SteamStorageApiOptions>? configureOptions)
    {
        SteamStorageApiOptions options = new();
        configureOptions?.Invoke(options);

        //Main HttpClient
        services.AddHttpClient(ApiConstants.CLIENT_NAME,
                client =>
                {
                    client.Timeout = TimeSpan.FromSeconds(options.ClientTimeout);
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
        services.AddSingleton<ApiClient>();

        return services;
    }
    
    public static IServiceCollection AddSteamStorageApiWeb(
        this IServiceCollection services,
        Action<SteamStorageApiOptions>? configureOptions)
    {
        SteamStorageApiOptions options = new();
        configureOptions?.Invoke(options);

        //HttpContextAccessor
        services.AddHttpContextAccessor();
        
        //Main HttpClient
        services.AddHttpClient(ApiConstants.CLIENT_NAME,
                client =>
                {
                    client.Timeout = TimeSpan.FromSeconds(options.ClientTimeout);
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
        services.AddScoped<ApiClient>();

        return services;
    }

    public static IServiceCollection AddSteamStorageLoggerService(
        this IServiceCollection services,
        Action<SteamStorageLoggerOptions>? configureOptions)
    {
        SteamStorageLoggerOptions options = new();
        configureOptions?.Invoke(options);

        //LoggerService
        services.AddSingleton<ILoggerService, LoggerService>(_ =>
            new(options.ProgramName,
                options.DateFormat,
                options.DateTimeFormat,
                options.LogFilesLifetime));

        return services;
    }

    public static IServiceCollection AddSteamStorageAuthorizationService(
        this IServiceCollection services)
    {
        //AuthorizationService
        services.AddScoped<IAuthorizationService, AuthorizationService>();

        return services;
    }

    public static IServiceCollection AddSteamStoragePingService(
        this IServiceCollection services)
    {
        //PingService
        services.AddScoped<IPingService, PingService>(_ =>
            new(ApiConstants.HOST_NAME));

        return services;
    }
    
    public static IServiceCollection AddSteamStorageReferenceInformationService(
        this IServiceCollection services)
    {
        //ReferenceInformationService
        services.AddScoped<IReferenceInformationService, ReferenceInformationService>();

        return services;
    }

    #endregion Methods
}
