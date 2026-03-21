// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace SteamStorageAPI.SDK.Utilities.Extensions.ServiceCollection.Api;

public class ApiClientOptions
{
    #region Properties

    public int ClientTimeout { get; set; } = 15;
    
    public string ClientName { get; set; } = "MainClient";
    
    public string HostName { get; set; } = "steamstorage.ru";
    
    public string ServerAddress { get; set; } = "https://steamstorage.ru";
    
    public string ApiAddress { get; set; } = "https://steamstorage.ru/api";
    
    public string TokenHubEndpoint { get; set; } = "https://steamstorage.ru/token/token-hub";

    #endregion Properties
}