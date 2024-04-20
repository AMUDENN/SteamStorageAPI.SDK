using SteamStorageAPI.SDK.ApiEntities.Tools;
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable UnusedType.Global

namespace SteamStorageAPI.SDK.ApiEntities;

public static class Currencies
{
    #region Records

    public record CurrencyResponse(
        int Id,
        int SteamCurrencyId,
        string Title,
        string Mark,
        string CultureInfo,
        double Price,
        DateTime DateUpdate) : Response;

    public record CurrenciesResponse(
        int Count,
        IEnumerable<CurrencyResponse>? Currencies) : Response;

    public record GetCurrencyRequest(
        int Id) : Request;

    public record PostCurrencyRequest(
        int SteamCurrencyId,
        string Title,
        string Mark) : Request;

    public record PutCurrencyRequest(
        int CurrencyId,
        string Title,
        string Mark) : Request;

    public record SetCurrencyRequest(
        int CurrencyId) : Request;

    public record DeleteCurrencyRequest(
        int CurrencyId) : Request;

    #endregion Records
}
