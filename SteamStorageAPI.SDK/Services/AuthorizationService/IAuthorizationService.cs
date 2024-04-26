// ReSharper disable UnusedMember.Global

namespace SteamStorageAPI.SDK.Services.AuthorizationService;

public interface IAuthorizationService
{
    public void LogIn();

    public void LogIn(string returnTo);

    public void LogOut();
}
