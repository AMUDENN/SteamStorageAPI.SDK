namespace SteamStorageAPI.SDK.Utilities.Extensions.ServiceCollection.Ping;

public class PingServiceOptions
{
    #region Properties

    public TimeSpan PingTimeout { get; set; } = TimeSpan.FromMilliseconds(300);

    #endregion Properties
}