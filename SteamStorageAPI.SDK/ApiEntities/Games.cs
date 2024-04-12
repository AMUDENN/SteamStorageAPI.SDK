using SteamStorageAPI.SDK.ApiEntities.Tools;

namespace SteamStorageAPI.SDK.ApiEntities;

public static class Games
{
    #region Records

    public record GameResponse(
        int Id,
        int SteamGameId,
        string Title,
        string GameIconUrl) : Response;
    
    public record GamesResponse(
        int Count,
        IEnumerable<GameResponse>? Games) : Response;

    #endregion Records
}
