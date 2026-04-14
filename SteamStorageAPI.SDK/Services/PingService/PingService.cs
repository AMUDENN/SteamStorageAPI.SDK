using System.Net.NetworkInformation;
using SteamStorageAPI.SDK.ApiClient;

namespace SteamStorageAPI.SDK.Services.PingService;

public class PingService : IPingService
{
    #region Constructor

    public PingService(
        IApiClient apiClient,
        TimeSpan timeout)
    {
        _apiClient = apiClient;

        _timeout = timeout;
    }

    #endregion Constructor

    #region Methods

    public async Task<PingResult> GetPingAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            using Ping pingSender = new();
            PingReply reply = await pingSender.SendPingAsync(
                _apiClient.HostName,
                _timeout,
                null,
                null,
                cancellationToken);
            if (reply.Status == IPStatus.Success) return new PingResult(reply.RoundtripTime);
        }
        catch
        {
            return new PingResult(-1);
        }

        return new PingResult(-1);
    }

    #endregion Methods

    #region Fields

    private readonly IApiClient _apiClient;

    private readonly TimeSpan _timeout;

    #endregion Fields
}