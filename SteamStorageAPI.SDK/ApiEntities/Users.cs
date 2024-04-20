using SteamStorageAPI.SDK.ApiEntities.Tools;
// ReSharper disable NotAccessedPositionalProperty.Global

namespace SteamStorageAPI.SDK.ApiEntities;

public static class Users
{
    #region Records

    public record UserResponse(
        int UserId,
        long SteamId,
        string ProfileUrl,
        string? ImageUrl,
        string? ImageUrlMedium,
        string? ImageUrlFull,
        string? Nickname,
        string Role,
        int StartPageId,
        string StartPage,
        int CurrencyId,
        DateTime DateRegistration,
        decimal? GoalSum) : Response;
    
    public record UsersResponse(
        int Count,
        IEnumerable<UserResponse>? Users) : Response;
    
    public record GoalSumResponse(
        decimal? GoalSum) : Response;
    
    public record GetUserRequest(
        int UserId) : Request;

    public record PutGoalSumRequest(
        decimal? GoalSum) : Request;

    #endregion Records
}
