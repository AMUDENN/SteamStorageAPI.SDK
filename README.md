# SteamStorageAPI.SDK

A .NET 10 client library for interacting with the [SteamStorage API](https://github.com/AMUDENN/SteamStorageAPI).
Provides a typed HTTP client, Steam OAuth authorization via SignalR, ping utilities, and a clean event-driven error
handling model.

---

## Installation

**Package Manager:**

```
Install-Package SteamStorageAPI.SDK
```

**.NET CLI:**

```
dotnet add package SteamStorageAPI.SDK
```

---

## Quick Start

### Desktop / WPF / Avalonia

Register the SDK in your DI container:

```csharp
services.AddSteamStorageApi(options =>
{
    options.ClientName       = "MainClient"
    options.ServerAddress    = "https://your-server.com";
    options.ApiAddress       = "https://your-server.com/api";
    options.HostName         = "your-server.com";
    options.TokenHubEndpoint = "https://your-server.com/token/token-hub";
});

services.AddSteamStorageAuthorizationService(options =>
{
    options.TokenHubTimeout = TimeSpan.FromMinutes(2);
});

services.AddSteamStoragePingService(options =>
{
    options.PingTimeout = TimeSpan.FromSeconds(5);
});
```

### ASP.NET Core (Web)

Use `AddSteamStorageApiWeb` instead — it resolves `IApiClient` per request via `IHttpContextAccessor`:

```csharp
services.AddSteamStorageApiWeb(options =>
{
    options.ClientName       = "MainClient"
    options.ServerAddress    = "https://your-server.com";
    options.ApiAddress       = "https://your-server.com/api";
    options.HostName         = "your-server.com";
    options.TokenHubEndpoint = "https://your-server.com/token/token-hub";
});
```

---

## Authorization

```csharp
public class MyViewModel
{
    private readonly IAuthorizationService _authService;

    public MyViewModel(IAuthorizationService authService)
    {
        _authService = authService;
        _authService.AuthorizationCompleted += OnAuthorizationCompleted;
        _authService.LogOutCompleted        += OnLogOutCompleted;
    }

    // Opens a browser for Steam OAuth and waits for a token via SignalR
    public async Task LoginAsync()
        => await _authService.LogInAsync();

    // For web flows — redirects to Steam with a custom return URL
    public async Task LoginWebAsync(string returnUrl)
        => await _authService.LogInAsync(returnUrl);

    public async Task LogoutAsync()
        => await _authService.LogOutAsync();

    private void OnAuthorizationCompleted(object? sender) { /* update UI */ }
    private void OnLogOutCompleted(object? sender)        { /* clear session */ }
}
```

---

## Making API Requests

Inject `IApiClient` and call `GetAsync`, `PostAsync`, `PutAsync`, or `DeleteAsync` with a typed method enum:

```csharp
// GET with no parameters
var currencies = await _apiClient.GetAsync<Currencies.CurrenciesResponse>(
    ApiConstants.ApiMethods.GetCurrencies);

// GET with query parameters
var actives = await _apiClient.GetAsync<Actives.ActivesResponse, Actives.GetActivesRequest>(
    ApiConstants.ApiMethods.GetActives,
    new Actives.GetActivesRequest(groupId: 1, page: 1));

// POST with body
await _apiClient.PostAsync(
    ApiConstants.ApiMethods.PostActiveGroup,
    new ActiveGroups.PostActiveGroupRequest("My Group", ...));

// DELETE with body
await _apiClient.DeleteAsync(
    ApiConstants.ApiMethods.DeleteActiveGroup,
    new ActiveGroups.DeleteActiveGroupRequest(groupId: 5));

// Download a file
File.FileResponse? file = await _apiClient.GetFileAsync(
    ApiConstants.ApiMethods.GetExportFile);
```

All methods accept an optional `CancellationToken`.

---

## Event-Driven Error Handling

`IApiClient` exposes four events — subscribe to them once at startup instead of wrapping every call in try-catch:

```csharp
_apiClient.TokenChanged      += OnTokenChanged;
_apiClient.OperationCanceled += OnOperationCanceled;
_apiClient.ApiException      += OnApiException;
_apiClient.UnhandledException += OnUnhandledException;

private void OnTokenChanged(object? sender, TokenChangedEventArgs e)
{
    // e.Token is null on logout / 401
    Console.WriteLine($"Token changed: {e.Token}");
}

private void OnOperationCanceled(object? sender)
{
    // Request was cancelled via CancellationToken
}

private void OnApiException(object? sender, ApiExceptionEventArgs e)
{
    // 4xx / 5xx from the API — e.Exception.Message contains the server error text
    Console.WriteLine($"API error: {e.Exception.Message}");
}

private void OnUnhandledException(object? sender, UnhandledExceptionEventArgs e)
{
    // Network failure, timeout, JSON parse error, etc.
    Console.WriteLine($"Unexpected error: {e.Exception}");
}
```

> **401 Unauthorized** is handled automatically — `Token` is set to `null` and `TokenChanged` fires before
`ApiException`.

---

## Ping

```csharp
PingResult result = await _pingService.GetPingAsync();

if (result.RoundtripTime >= 0)
    Console.WriteLine($"Latency: {result.RoundtripTime} ms");
else
    Console.WriteLine("Host unreachable");
```

---

## Configuration Reference

### `ApiClientOptions`

| Property           | Type     | Default        | Description                        |
|--------------------|----------|----------------|------------------------------------|
| `ClientName`       | `string` | `"MainClient"` | Named `HttpClient` identifier      |
| `ClientTimeout`    | `int`    | `15`           | HTTP timeout in seconds            |
| `HostName`         | `string` | —              | Hostname used for ping             |
| `ServerAddress`    | `string` | —              | Base server URL                    |
| `ApiAddress`       | `string` | —              | API root URL                       |
| `TokenHubEndpoint` | `string` | —              | SignalR hub URL for token delivery |

### `AuthorizationServiceOptions`

| Property          | Type       | Description                                      |
|-------------------|------------|--------------------------------------------------|
| `TokenHubTimeout` | `TimeSpan` | How long to wait for a token after browser login |

### `PingServiceOptions`

| Property      | Type       | Description           |
|---------------|------------|-----------------------|
| `PingTimeout` | `TimeSpan` | Timeout for ICMP ping |

---

## Architecture Overview

```
IApiClient
├── TokenHandler / WebTokenHandler      — attaches Bearer token to every request
├── ApiExceptionHandler / WebApiExceptionHandler  — converts non-2xx to ApiException
└── ApiClient
    ├── ExecuteAsync                    — central try/catch, fires events
    ├── GetAsync / PostAsync / PutAsync / DeleteAsync
    └── Events: TokenChanged | OperationCanceled | ApiException | UnhandledException

IAuthorizationService
└── AuthorizationService
    ├── LogInAsync      — opens browser → waits for token via SignalR hub
    └── LogOutAsync     — clears token, fires LogOutCompleted

IPingService
└── PingService         — ICMP ping to HostName
```

---

## Requirements

- .NET 10.0+
- Dependencies: `Flurl`, `Microsoft.AspNetCore.SignalR.Client`, `Microsoft.Extensions.Http`

---

## License

See [LICENSE](LICENSE) for details.