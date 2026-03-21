using SteamStorageAPI.SDK.ApiEntities.Tools.Response;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace SteamStorageAPI.SDK.ApiEntities;

public static class File
{
    #region Records

    public record FileResponse : Response, IAsyncDisposable, IDisposable
    {
        #region Properties

        public Stream Stream { get; }

        public string FileName { get; }

        #endregion Properties

        #region Constructor

        public FileResponse(Stream stream, string fileName)
        {
            Stream = stream;
            FileName = fileName;
        }

        #endregion Constructor

        #region IDisposable

        public void Dispose()
        {
            Stream.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable

        #region IAsyncDisposable

        public async ValueTask DisposeAsync()
        {
            await Stream.DisposeAsync();
            GC.SuppressFinalize(this);
        }

        #endregion IAsyncDisposable
    }

    #endregion Records
}