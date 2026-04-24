using SteamStorageAPI.SDK.ApiEntities.Tools.Request;
using SteamStorageAPI.SDK.ApiEntities.Tools.Response;

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

    public record ExchangeTokenResponse(
        string Token) : Response;

    #endregion Records
}