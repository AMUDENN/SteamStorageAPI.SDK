using SteamStorageAPI.SDK.ApiClient;
using SteamStorageAPI.SDK.Utilities.UrlUtility;

namespace SteamStorageAPI.SDK.Services.ReferenceInformationService;

public class ReferenceInformationService : IReferenceInformationService
{
    #region Fields
    
    private readonly IApiClient _apiClient;
    
    #endregion Fields
    
    #region Constructor

    public ReferenceInformationService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }
    
    #endregion Constructor
    
    #region Methods

    public void OpenReferenceInformation()
    {
        UrlUtility.OpenUrl(_apiClient.ServerAddress);
    }

    #endregion Methods
}