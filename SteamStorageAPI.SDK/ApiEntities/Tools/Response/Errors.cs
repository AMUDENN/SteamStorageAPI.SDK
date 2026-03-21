// ReSharper disable UnusedType.Global
// ReSharper disable NotAccessedPositionalProperty.Global

namespace SteamStorageAPI.SDK.ApiEntities.Tools.Response;

public static class Errors
{
    #region Records

    public record ErrorResponse(string Message) : Response;

    #endregion Records
}