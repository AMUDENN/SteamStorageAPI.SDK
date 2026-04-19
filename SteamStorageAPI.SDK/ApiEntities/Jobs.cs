using SteamStorageAPI.SDK.ApiEntities.Tools.Request;

namespace SteamStorageAPI.SDK.ApiEntities;

// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable UnusedType.Global

public static class Jobs
{
    #region Enums

    public enum JobName
    {
        RefreshSkinDynamicsJob,
        RefreshCurrenciesJob,
        RefreshActiveGroupsDynamicsJob
    }

    #endregion Enums

    #region Records

    public record TriggerJobRequest(
        JobName JobName) : Request;

    #endregion Records
}