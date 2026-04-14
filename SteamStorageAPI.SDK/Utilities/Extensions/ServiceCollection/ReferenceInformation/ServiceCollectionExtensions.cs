using Microsoft.Extensions.DependencyInjection;
using SteamStorageAPI.SDK.Services.ReferenceInformationService;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace SteamStorageAPI.SDK.Utilities.Extensions.ServiceCollection.ReferenceInformation;

public static class ServiceCollectionExtensions
{
    #region Methods

    public static IServiceCollection AddSteamStorageReferenceInformationService(
        this IServiceCollection services)
    {
        //ReferenceInformationService
        services.AddScoped<IReferenceInformationService, ReferenceInformationService>();

        return services;
    }

    #endregion Methods
}