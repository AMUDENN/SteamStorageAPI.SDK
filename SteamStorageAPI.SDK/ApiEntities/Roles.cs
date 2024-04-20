using SteamStorageAPI.SDK.ApiEntities.Tools;
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable UnusedType.Global

namespace SteamStorageAPI.SDK.ApiEntities;

public static class Roles
{
    #region Records

    public record RoleResponse(
        int Id,
        string Title) : Response;

    public record RolesResponse(
        int Count,
        IEnumerable<RoleResponse>? Roles) : Response;

    public record SetRoleRequest(
        int UserId,
        int RoleId) : Request;

    #endregion Records
}
