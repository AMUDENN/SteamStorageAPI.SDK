using SteamStorageAPI.SDK.ApiEntities.Tools;
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable UnusedType.Global

namespace SteamStorageAPI.SDK.ApiEntities;

public static class Users
{
    #region Records

    public record UserResponse(
        int UserId,
        string SteamId,
        string ProfileUrl,
        string? ImageUrl,
        string? ImageUrlMedium,
        string? ImageUrlFull,
        string? Nickname,
        int RoleId,
        string Role,
        int StartPageId,
        string StartPage,
        int CurrencyId,
        DateTime DateRegistration,
        decimal? GoalSum) : Response;
    
    public record UsersResponse(
        int Count,
        int PagesCount,
        IEnumerable<UserResponse> Users) : Response;

    public record UsersCountResponse(
        int Count) : Response;
    
    public record GoalSumResponse(
        decimal? GoalSum) : Response;

    public record GetUsersRequest(
        int PageNumber,
        int PageSize) : Request;
    
    public record GetUserRequest(
        int UserId) : Request;

    public record PutGoalSumRequest(
        decimal? GoalSum) : Request;

    #endregion Records
}
