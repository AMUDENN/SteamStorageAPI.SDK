// ReSharper disable UnusedMember.Global
// ReSharper disable EventNeverSubscribedTo.Global

namespace SteamStorageAPI.SDK.Services.AuthorizationService;

public interface IAuthorizationService
{
    public delegate void AuthorizationCompletedEventHandler(object? sender);

    public delegate void LogOutCompletedEventHandler(object? sender);

    public event AuthorizationCompletedEventHandler? AuthorizationCompleted;

    public event LogOutCompletedEventHandler? LogOutCompleted;

    public Task LogInAsync(CancellationToken cancellationToken = default);

    public Task LogInAsync(string returnTo, CancellationToken cancellationToken = default);

    public Task LogOutAsync(CancellationToken cancellationToken = default);
}