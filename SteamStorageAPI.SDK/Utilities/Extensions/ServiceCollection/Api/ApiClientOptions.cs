// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace SteamStorageAPI.SDK.Utilities.Extensions.ServiceCollection.Api;

public class ApiClientOptions
{
    #region Properties

    public TimeSpan ClientTimeout { get; set; } = TimeSpan.FromSeconds(15);

    public string ClientName { get; set; } = string.Empty;

    public string HostName { get; set; } = string.Empty;

    public string ServerAddress { get; set; } = string.Empty;

    public string ApiAddress { get; set; } = string.Empty;

    public string TokenHubEndpoint { get; set; } = string.Empty;

    #endregion Properties
}