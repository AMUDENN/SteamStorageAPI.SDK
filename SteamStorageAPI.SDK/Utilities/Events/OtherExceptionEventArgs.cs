// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace SteamStorageAPI.SDK.Utilities.Events;

public class OtherExceptionEventArgs : EventArgs
{
    #region Constructor

    public OtherExceptionEventArgs(
        Exception exception)
    {
        Exception = exception;
    }

    #endregion Constructor

    #region Properties

    public Exception Exception { get; }

    #endregion Properties
}