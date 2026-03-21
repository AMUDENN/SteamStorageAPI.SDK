// ReSharper disable UnusedMember.Global

namespace SteamStorageAPI.SDK.Services.PingService;

public interface IPingService
{
    public Task<PingResult> GetPingAsync(CancellationToken cancellationToken = default);
}