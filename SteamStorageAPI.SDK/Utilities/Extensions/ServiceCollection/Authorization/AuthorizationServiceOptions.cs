// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace SteamStorageAPI.SDK.Utilities.Extensions.ServiceCollection.Authorization;

public class AuthorizationServiceOptions
{
    #region Properties

    public TimeSpan TokenHubTimeout { get; set; } = TimeSpan.FromSeconds(300);
    
    #endregion Properties
}