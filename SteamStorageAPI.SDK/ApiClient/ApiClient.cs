using System.Net.Http.Json;
using Flurl;
using Microsoft.Extensions.Logging;
using SteamStorageAPI.SDK.ApiEntities.Tools.Request;
using SteamStorageAPI.SDK.ApiEntities.Tools.Response;
using SteamStorageAPI.SDK.Utilities.ApiControllers;
using SteamStorageAPI.SDK.Utilities.Events;
using SteamStorageAPI.SDK.Utilities.Exceptions;
using File = SteamStorageAPI.SDK.ApiEntities.File;

// ReSharper disable UnusedMember.Global
// ReSharper disable EventNeverSubscribedTo.Global

namespace SteamStorageAPI.SDK.ApiClient;

public class ApiClient : IApiClient
{
    #region Fields

    private readonly ILogger<IApiClient>? _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    private string? _token;

    #endregion Fields

    #region Properties

    public string? Token
    {
        get => _token;
        set
        {
            _token = value;
            OnTokenChanged(value);
        }
    }

    public string ClientName { get; }

    public string HostName { get; }

    public string ServerAddress { get; }

    public string ApiAddress { get; }

    public string TokenHubEndpoint { get; }

    #endregion Properties

    #region Constructor

    public ApiClient(
        ILogger<IApiClient>? logger,
        IHttpClientFactory httpClientFactory,
        string clientName,
        string hostName,
        string serverAddress,
        string apiAddress,
        string tokenHubEndpoint)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;

        ClientName = clientName;
        HostName = hostName;
        ServerAddress = serverAddress;
        ApiAddress = apiAddress;
        TokenHubEndpoint = tokenHubEndpoint;

        _token = null;
    }

    #endregion Constructor

    #region Events

    public event IApiClient.TokenChangedEventHandler? TokenChanged;

    public event IApiClient.OperationCanceledHandler? OperationCanceled;

    public event IApiClient.ApiExceptionHandler? ApiException;

    public event IApiClient.OtherExceptionHandler? Exception;

    #endregion Events

    #region Execute

    private async Task<TOut?> ExecuteAsync<TOut>(
        Func<HttpClient, Task<TOut?>> action,
        Uri uri)
    {
        try
        {
            HttpClient client = _httpClientFactory.CreateClient(ClientName);
            return await action(client);
        }
        catch (OperationCanceledException)
        {
            OnOperationCanceled();
            return default;
        }
        catch (ApiException ex)
        {
            _logger?.LogError(ex, "ApiException {Uri}", uri);
            OnApiException(ex);
            return default;
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Exception {Uri}", uri);
            OnOtherException(ex);
            return default;
        }
    }

    private async Task ExecuteAsync(
        Func<HttpClient, Task> action,
        Uri uri)
    {
        await ExecuteAsync<object?>(async client =>
            {
                await action(client);
                return null;
            },
            uri);
    }

    #endregion Execute

    #region GET

    private async Task<TOut?> GetAsync<TOut>(
        Uri uri,
        CancellationToken cancellationToken = default)
        where TOut : Response
    {
        return await ExecuteAsync(async client =>
            {
                HttpResponseMessage response = await client.GetAsync(uri, cancellationToken);
                return await response.Content.ReadFromJsonAsync<TOut>(cancellationToken);
            },
            uri);
    }

    public async Task<TOut?> GetAsync<TOut>(
        ApiConstants.ApiMethods apiMethod,
        CancellationToken cancellationToken = default)
        where TOut : Response
    {
        return await GetAsync<TOut>(
            CreateUri(ApiConstants.GetController(apiMethod), apiMethod),
            cancellationToken);
    }

    public async Task<TOut?> GetAsync<TOut, TIn>(
        ApiConstants.ApiMethods apiMethod,
        TIn? args = null,
        CancellationToken cancellationToken = default)
        where TOut : Response
        where TIn : Request
    {
        return await GetAsync<TOut>(
            CreateUri(ApiConstants.GetController(apiMethod), apiMethod, args),
            cancellationToken);
    }

    public async Task<File.FileResponse?> GetFileAsync(
        ApiConstants.ApiMethods apiMethod,
        CancellationToken cancellationToken = default)
    {
        Uri uri = CreateUri(ApiConstants.GetController(apiMethod), apiMethod);

        return await ExecuteAsync(async client =>
            {
                HttpResponseMessage response = await client.GetAsync(uri, cancellationToken);
                response.EnsureSuccessStatusCode();
                string fileName = response.Content.Headers.ContentDisposition?.FileName ?? string.Empty;
                Stream fileStream = await response.Content.ReadAsStreamAsync(cancellationToken);
                return new File.FileResponse(fileStream, fileName);
            },
            uri);
    }

    #endregion GET

    #region POST

    private async Task PostAsync<TIn>(
        Uri uri,
        TIn? args = null,
        CancellationToken cancellationToken = default)
        where TIn : Request
    {
        await ExecuteAsync(
            async client =>
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(uri, args, cancellationToken);
                return response;
            },
            uri);
    }

    public async Task PostAsync<TIn>(
        ApiConstants.ApiMethods apiMethod,
        TIn? args = null,
        CancellationToken cancellationToken = default)
        where TIn : Request
    {
        await PostAsync(
            CreateUri(ApiConstants.GetController(apiMethod), apiMethod),
            args,
            cancellationToken);
    }

    public async Task PostAsync(
        ApiConstants.ApiMethods apiMethod,
        CancellationToken cancellationToken = default)
    {
        await PostAsync<Request>(
            CreateUri(ApiConstants.GetController(apiMethod), apiMethod),
            null,
            cancellationToken);
    }

    #endregion POST

    #region PUT

    private async Task PutAsync<TIn>(
        Uri uri,
        TIn? args = null,
        CancellationToken cancellationToken = default)
        where TIn : Request
    {
        await ExecuteAsync(
            async client =>
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(uri, args, cancellationToken);
                return response;
            },
            uri);
    }

    public async Task PutAsync<TIn>(
        ApiConstants.ApiMethods apiMethod,
        TIn? args = null,
        CancellationToken cancellationToken = default)
        where TIn : Request
    {
        await PutAsync(
            CreateUri(ApiConstants.GetController(apiMethod), apiMethod),
            args,
            cancellationToken);
    }

    public async Task PutAsync(
        ApiConstants.ApiMethods apiMethod,
        CancellationToken cancellationToken = default)
    {
        await PutAsync<Request>(
            CreateUri(ApiConstants.GetController(apiMethod), apiMethod),
            null,
            cancellationToken);
    }

    #endregion PUT

    #region DELETE

    private async Task DeleteAsync<TIn>(
        Uri uri,
        TIn? args = null,
        CancellationToken cancellationToken = default)
        where TIn : Request
    {
        await ExecuteAsync(
            async client =>
            {
                HttpRequestMessage request = new()
                {
                    Content = JsonContent.Create(args),
                    Method = HttpMethod.Delete,
                    RequestUri = uri
                };
                HttpResponseMessage response = await client.SendAsync(request, cancellationToken);
                return response;
            },
            uri);
    }

    public async Task DeleteAsync<TIn>(
        ApiConstants.ApiMethods apiMethod,
        TIn? args = null,
        CancellationToken cancellationToken = default)
        where TIn : Request
    {
        await DeleteAsync(
            CreateUri(ApiConstants.GetController(apiMethod), apiMethod),
            args,
            cancellationToken);
    }

    public async Task DeleteAsync(
        ApiConstants.ApiMethods apiMethod,
        CancellationToken cancellationToken = default)
    {
        await DeleteAsync<Request>(
            CreateUri(ApiConstants.GetController(apiMethod), apiMethod),
            null,
            cancellationToken);
    }

    #endregion DELETE

    #region Methods

    private string CreateStringUri(
        ApiConstants.ApiControllers apiController,
        ApiConstants.ApiMethods apiMethod)
    {
        return $"{ApiAddress}/{apiController}/{apiMethod}";
    }

    private Uri CreateUri(
        ApiConstants.ApiControllers apiController,
        ApiConstants.ApiMethods apiMethod)
    {
        return new Uri(CreateStringUri(apiController, apiMethod));
    }

    private Uri CreateUri<TIn>(
        ApiConstants.ApiControllers apiController,
        ApiConstants.ApiMethods apiMethod,
        TIn? args = null)
        where TIn : Request
    {
        string uri = CreateStringUri(apiController, apiMethod);
        return args is null ? new Uri(uri) : new Uri(uri.SetQueryParams(args));
    }

    private void OnTokenChanged(
        string? token)
    {
        TokenChanged?.Invoke(this, new TokenChangedEventArgs(token));
    }

    private void OnOperationCanceled()
    {
        OperationCanceled?.Invoke(this);
    }

    private void OnApiException(ApiException exception)
    {
        ApiException?.Invoke(this, new ApiExceptionEventArgs(exception));
    }

    private void OnOtherException(Exception exception)
    {
        Exception?.Invoke(this, new OtherExceptionEventArgs(exception));
    }

    #endregion Methods
}