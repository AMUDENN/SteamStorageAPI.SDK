using SteamStorageAPI.SDK.ApiEntities.Tools;
// ReSharper disable NotAccessedPositionalProperty.Global

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

    public record PostGameRequest(
        int SteamGameId,
        string IconUrlHash) : Request;

    public record PutGameRequest(
        int GameId,
        string IconUrlHash,
        string Title) : Request;

    public record DeleteGameRequest(
        int GameId) : Request;

    #endregion Records
}
