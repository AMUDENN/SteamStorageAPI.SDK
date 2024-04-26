using SteamStorageAPI.SDK.ApiEntities.Tools;
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable UnusedType.Global

namespace SteamStorageAPI.SDK.ApiEntities;

public static class Authorize
{
    #region Records

    public record GetAuthUrlRequest(
        string? ReturnTo) : Request;
    
    public record AuthUrlResponse(
        string Url,
        string Group) : Response;

    #endregion Records
}
