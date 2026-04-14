using SteamStorageAPI.SDK.ApiEntities.Tools.Request;
using SteamStorageAPI.SDK.ApiEntities.Tools.Response;
using SteamStorageAPI.SDK.Utilities.ApiControllers;
using SteamStorageAPI.SDK.Utilities.Events;
using File = SteamStorageAPI.SDK.ApiEntities.File;

namespace SteamStorageAPI.SDK.ApiClient;

public interface IApiClient
{
    public delegate void ApiExceptionHandler(object? sender, ApiExceptionEventArgs args);

    public delegate void OperationCanceledHandler(object? sender);

    public delegate void TokenChangedEventHandler(object? sender, TokenChangedEventArgs args);

    public delegate void UnhandledExceptionHandler(object? sender, UnhandledExceptionEventArgs args);

    public string? Token { get; set; }

    public string ClientName { get; }

    public string HostName { get; }

    public string ServerAddress { get; }

    public string ApiAddress { get; }

    public string TokenHubEndpoint { get; }

    public event ApiExceptionHandler? ApiException;

    public event UnhandledExceptionHandler? Exception;

    public event OperationCanceledHandler? OperationCanceled;

    public event TokenChangedEventHandler? TokenChanged;

    public Task<TOut?> GetAsync<TOut>(
        ApiConstants.ApiMethods apiMethod,
        CancellationToken cancellationToken = default)
        where TOut : Response;

    public Task<TOut?> GetAsync<TOut, TIn>(
        ApiConstants.ApiMethods apiMethod,
        TIn? args = null,
        CancellationToken cancellationToken = default)
        where TOut : Response
        where TIn : Request;

    public Task<File.FileResponse?> GetFileAsync(
        ApiConstants.ApiMethods apiMethod,
        CancellationToken cancellationToken = default);

    public Task PostAsync<TIn>(
        ApiConstants.ApiMethods apiMethod,
        TIn? args = null,
        CancellationToken cancellationToken = default)
        where TIn : Request;

    public Task PostAsync(
        ApiConstants.ApiMethods apiMethod,
        CancellationToken cancellationToken = default);

    public Task PutAsync<TIn>(
        ApiConstants.ApiMethods apiMethod,
        TIn? args = null,
        CancellationToken cancellationToken = default)
        where TIn : Request;

    public Task PutAsync(
        ApiConstants.ApiMethods apiMethod,
        CancellationToken cancellationToken = default);

    public Task DeleteAsync<TIn>(
        ApiConstants.ApiMethods apiMethod,
        TIn? args = null,
        CancellationToken cancellationToken = default)
        where TIn : Request;

    public Task DeleteAsync(
        ApiConstants.ApiMethods apiMethod,
        CancellationToken cancellationToken = default);
}