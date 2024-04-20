using SteamStorageAPI.SDK.ApiEntities.Tools;
// ReSharper disable NotAccessedPositionalProperty.Global

namespace SteamStorageAPI.SDK.ApiEntities;

public static class Authorize
{
    #region Records

    public record AuthUrlResponse(
        string Url,
        string Group) : Response;

    #endregion Records
}
