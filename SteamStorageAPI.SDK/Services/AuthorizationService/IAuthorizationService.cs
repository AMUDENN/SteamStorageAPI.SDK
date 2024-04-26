// ReSharper disable UnusedMember.Global

namespace SteamStorageAPI.SDK.Services.AuthorizationService;

public interface IAuthorizationService
{
    public void LogIn();

    public Task LogInAsync();

    public void LogOut();

    public Task LogOutAsync();
}
