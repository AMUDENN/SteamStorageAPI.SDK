// ReSharper disable UnusedMember.Global
// ReSharper disable EventNeverSubscribedTo.Global

namespace SteamStorageAPI.SDK.Services.AuthorizationService;

public interface IAuthorizationService
{
    public delegate void AuthorizationCompletedEventHandler(object? sender);

    public event AuthorizationCompletedEventHandler? AuthorizationCompleted;
    
    public delegate void LogOutCompletedEventHandler(object? sender);

    public event LogOutCompletedEventHandler? LogOutCompleted;
    
    public void LogIn();

    public void LogIn(string returnTo);

    public void LogOut();
}
