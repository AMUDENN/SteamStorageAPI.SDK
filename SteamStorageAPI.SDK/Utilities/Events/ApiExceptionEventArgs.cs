// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace SteamStorageAPI.SDK.Utilities.Events;

public class ApiExceptionEventArgs : EventArgs
{
    #region Properties

    public Exception Exception { get; }

    #endregion Properties

    #region Constructor

    public ApiExceptionEventArgs(
        Exception exception)
    {
        Exception = exception;
    }

    #endregion Constructor
}
