using System.Net;
using System.Net.Http.Json;
using SteamStorageAPI.SDK.ApiEntities.Tools;

namespace SteamStorageAPI.SDK.Utilities.Exceptions;

[Serializable]
public class ApiException : Exception
{
    #region Fields

    private static HttpStatusCode[] _errorCodes =
    [
        HttpStatusCode.BadRequest, HttpStatusCode.NotFound
    ];

    #endregion Fields

    #region Constructor

    public ApiException()
    {

    }

    public ApiException(
        string? message) : base(message)
    {

    }

    public ApiException(
        string? message,
        Exception innerException) : base(message, innerException)
    {

    }

    #endregion Constructor

    #region Methods

    public static void ThrowIfUnauthorizedAccess(
        HttpResponseMessage message,
        ApiClient? apiClient)
    {
        if (message.StatusCode != HttpStatusCode.Unauthorized)
            return;
        if (apiClient is not null)
            apiClient.Token = string.Empty;
        throw new UnauthorizedAccessException("Некорректный авторизационный токен.");
    }

    public static async Task ThrowIfErrorAsync(
        HttpResponseMessage message,
        CancellationToken cancellationToken = default)
    {
        if (!_errorCodes.Contains(message.StatusCode))
            return;
        Errors.ErrorResponse? error = await message.Content.ReadFromJsonAsync<Errors.ErrorResponse>(cancellationToken);
        throw new ApiException(error?.Message);
    }

    #endregion Methods
}
