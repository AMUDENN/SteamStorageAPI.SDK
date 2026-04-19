using SteamStorageAPI.SDK.ApiEntities.Tools.Request;

// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable UnusedType.Global

namespace SteamStorageAPI.SDK.ApiEntities;

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