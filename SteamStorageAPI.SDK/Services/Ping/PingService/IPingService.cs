namespace SteamStorageAPI.SDK.Services.Ping.PingService;

public interface IPingService
{
    public Task<PingResult.PingResult> GetPing();
}
