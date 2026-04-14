using System.Net;
using System.Net.Http.Json;
using SteamStorageAPI.SDK.ApiClient;
using SteamStorageAPI.SDK.ApiEntities.Tools.Response;

namespace SteamStorageAPI.SDK.Utilities.Exceptions;

[Serializable]
public class ApiException : Exception
{
    #region Methods

    public static async Task ThrowIfErrorAsync(
        HttpResponseMessage message,
        IApiClient? apiClient,
        CancellationToken cancellationToken = default)
    {
        if (message.IsSuccessStatusCode) return;
        if (message.StatusCode == HttpStatusCode.Unauthorized && apiClient is not null) apiClient.Token = null;
        Errors.ErrorResponse? error = await message.Content.ReadFromJsonAsync<Errors.ErrorResponse>(cancellationToken);
        throw new ApiException(error?.Message);
    }

    #endregion Methods

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
}