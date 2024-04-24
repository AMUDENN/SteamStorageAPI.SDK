using SteamStorageAPI.SDK.Utilities;

namespace SteamStorageAPI.SDK.Services.ReferenceInformationService;

public class ReferenceInformationService : IReferenceInformationService
{
    #region Methods

    public void OpenReferenceInformation()
    {
        UrlUtility.OpenUrl(ApiConstants.SERVER_ADDRESS);
    }

    #endregion Methods
}
