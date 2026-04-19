using SteamStorageAPI.SDK.ApiEntities.Tools.Request;
using SteamStorageAPI.SDK.ApiEntities.Tools.Response;

// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable UnusedType.Global

namespace SteamStorageAPI.SDK.ApiEntities;

public static class Statistics
{
    #region Records

    public record InvestmentSumResponse(
        double TotalSum,
        double PercentageGrowth) : Response;

    public record FinancialGoalResponse(
        double FinancialGoal,
        double PercentageCompletion) : Response;

    public record ActiveStatisticResponse(
        int Count,
        double CurrentSum,
        double PercentageGrowth) : Response;

    public record ArchiveStatisticResponse(
        int Count,
        double SoldSum,
        double PercentageGrowth) : Response;

    public record InventoryStatisticResponse(
        int Count,
        double Sum,
        IEnumerable<InventoryGameStatisticResponse>? Games) : Response;

    public record InventoryGameStatisticResponse(
        string GameTitle,
        double Percentage,
        int Count) : Response;

    public record ItemsCountResponse(
        int Count) : Response;

    public record UsersCountByCurrencyItemResponse(
        int CurrencyId,
        string CurrencyTitle,
        int UsersCount) : Response;

    public record UsersCountByCurrencyResponse(
        IEnumerable<UsersCountByCurrencyItemResponse> Items) : Response;

    public record GetItemsCountByGameRequest(
        int GameId) : Request;

    #endregion Records
}