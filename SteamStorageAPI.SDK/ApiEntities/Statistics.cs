using SteamStorageAPI.SDK.ApiEntities.Tools.Request;
using SteamStorageAPI.SDK.ApiEntities.Tools.Response;

// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable UnusedType.Global

namespace SteamStorageAPI.SDK.ApiEntities;

public static class Statistics
{
    #region Records

    public record InvestmentSumResponse(
        decimal TotalSum,
        decimal PercentageGrowth) : Response;

    public record FinancialGoalResponse(
        decimal FinancialGoal,
        decimal PercentageCompletion) : Response;

    public record ActiveStatisticResponse(
        int Count,
        decimal CurrentSum,
        decimal PercentageGrowth) : Response;

    public record ArchiveStatisticResponse(
        int Count,
        decimal SoldSum,
        decimal PercentageGrowth) : Response;

    public record InventoryStatisticResponse(
        int Count,
        decimal Sum,
        IEnumerable<InventoryGameStatisticResponse>? Games) : Response;

    public record InventoryGameStatisticResponse(
        string GameTitle,
        decimal Percentage,
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