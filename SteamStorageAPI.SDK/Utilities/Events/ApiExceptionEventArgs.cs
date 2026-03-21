// ReSharper disable UnusedAutoPropertyAccessor.Global

using SteamStorageAPI.SDK.Utilities.Exceptions;

namespace SteamStorageAPI.SDK.Utilities.Events;

public class ApiExceptionEventArgs : EventArgs
{
    #region Constructor

    public ApiExceptionEventArgs(
        ApiException exception)
    {
        Exception = exception;
    }

    #endregion Constructor

    #region Properties

    public ApiException Exception { get; }

    #endregion Properties
}