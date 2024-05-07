// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable UnusedType.Global

namespace SteamStorageAPI.SDK.ApiEntities.Tools;

public static class Errors
{
    #region Records

    public record ErrorResponse(string Message) : Response;

    #endregion Records
}
