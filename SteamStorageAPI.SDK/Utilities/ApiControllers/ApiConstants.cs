// ReSharper disable UnusedMember.Global

using System.Reflection;

namespace SteamStorageAPI.SDK.Utilities.ApiControllers;

public static class ApiConstants
{
    #region Fields

    private static readonly Dictionary<ApiMethods, ApiControllers> ControllerMap =
        BuildControllerMap();

    #endregion Fields

    #region Constants

    internal const string TokenMethodName = "Token";
    internal const string JoinGroupMethodName = "JoinGroup";

    #endregion Constants

    #region Enums

    internal enum ApiControllers
    {
        ActiveGroups = 1,
        Actives,
        ArchiveGroups,
        Archives,
        Authorize,
        Currencies,
        File,
        Games,
        Inventory,
        Jobs,
        Pages,
        Roles,
        Skins,
        Statistics,
        Users
    }

    public enum ApiMethods
    {
        ///<summary>GET request</summary>
        [ApiController(ApiControllers.ActiveGroups)]
        GetActiveGroupInfo = 100,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.ActiveGroups)]
        GetActiveGroups,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.ActiveGroups)]
        GetActiveGroupsStatistic,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.ActiveGroups)]
        GetActiveGroupDynamics,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.ActiveGroups)]
        GetActiveGroupsCount,

        ///<summary>POST request</summary>
        [ApiController(ApiControllers.ActiveGroups)]
        PostActiveGroup,

        ///<summary>PUT request</summary>
        [ApiController(ApiControllers.ActiveGroups)]
        PutActiveGroup,

        ///<summary>DELETE request</summary>
        [ApiController(ApiControllers.ActiveGroups)]
        DeleteActiveGroup,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Actives)]
        GetActiveInfo = 200,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Actives)]
        GetActives,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Actives)]
        GetActivesStatistic,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Actives)]
        GetActivesPagesCount,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Actives)]
        GetActivesCount,

        ///<summary>POST request</summary>
        [ApiController(ApiControllers.Actives)]
        PostActive,

        ///<summary>PUT request</summary>
        [ApiController(ApiControllers.Actives)]
        PutActive,

        ///<summary>PUT request</summary>
        [ApiController(ApiControllers.Actives)]
        SoldActive,

        ///<summary>DELETE request</summary>
        [ApiController(ApiControllers.Actives)]
        DeleteActive,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.ArchiveGroups)]
        GetArchiveGroupInfo = 300,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.ArchiveGroups)]
        GetArchiveGroups,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.ArchiveGroups)]
        GetArchiveGroupsStatistic,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.ArchiveGroups)]
        GetArchiveGroupsCount,

        ///<summary>POST request</summary>
        [ApiController(ApiControllers.ArchiveGroups)]
        PostArchiveGroup,

        ///<summary>PUT request</summary>
        [ApiController(ApiControllers.ArchiveGroups)]
        PutArchiveGroup,

        ///<summary>DELETE request</summary>
        [ApiController(ApiControllers.ArchiveGroups)]
        DeleteArchiveGroup,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Archives)]
        GetArchiveInfo = 400,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Archives)]
        GetArchives,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Archives)]
        GetArchivesStatistic,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Archives)]
        GetArchivesPagesCount,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Archives)]
        GetArchivesCount,

        ///<summary>POST request</summary>
        [ApiController(ApiControllers.Archives)]
        PostArchive,

        ///<summary>PUT request</summary>
        [ApiController(ApiControllers.Archives)]
        PutArchive,

        ///<summary>DELETE request</summary>
        [ApiController(ApiControllers.Archives)]
        DeleteArchive,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Authorize)]
        GetAuthUrl = 500,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Currencies)]
        GetCurrencies = 600,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Currencies)]
        GetCurrency,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Currencies)]
        GetCurrentCurrency,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Currencies)]
        GetCurrencyDynamics,

        ///<summary>POST request</summary>
        [ApiController(ApiControllers.Currencies)]
        PostCurrency,

        ///<summary>PUT request</summary>
        [ApiController(ApiControllers.Currencies)]
        PutCurrencyInfo,

        ///<summary>PUT request</summary>
        [ApiController(ApiControllers.Currencies)]
        SetCurrency,

        ///<summary>DELETE request</summary>
        [ApiController(ApiControllers.Currencies)]
        DeleteCurrency,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.File)]
        GetExcelFile = 700,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Games)]
        GetGames = 800,

        ///<summary>POST request</summary>
        [ApiController(ApiControllers.Games)]
        PostGame,

        ///<summary>PUT request</summary>
        [ApiController(ApiControllers.Games)]
        PutGameInfo,

        ///<summary>DELETE request</summary>
        [ApiController(ApiControllers.Games)]
        DeleteGame,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Inventory)]
        GetInventory = 900,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Inventory)]
        GetInventoriesStatistic,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Inventory)]
        GetInventoryPagesCount,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Inventory)]
        GetSavedInventoriesCount,

        ///<summary>POST request</summary>
        [ApiController(ApiControllers.Inventory)]
        RefreshInventory,

        ///<summary>POST request</summary>
        [ApiController(ApiControllers.Jobs)]
        TriggerJob,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Pages)] GetPages = 1000,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Pages)] GetCurrentStartPage,

        ///<summary>PUT request</summary>
        [ApiController(ApiControllers.Pages)] SetStartPage,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Roles)] GetRoles = 1100,

        ///<summary>PUT request</summary>
        [ApiController(ApiControllers.Roles)] SetRole,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Skins)] GetSkinInfo = 1200,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Skins)] GetBaseSkins,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Skins)] GetSkins,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Skins)] GetSkinDynamics,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Skins)] GetSkinPagesCount,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Skins)] GetSteamSkinsCount,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Skins)] GetSavedSkinsCount,

        ///<summary>POST request</summary>
        [ApiController(ApiControllers.Skins)] PostSkin,

        ///<summary>PUT request</summary>
        [ApiController(ApiControllers.Skins)] SetMarkedSkin,

        ///<summary>DELETE request</summary>
        [ApiController(ApiControllers.Skins)] DeleteMarkedSkin,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Statistics)]
        GetInvestmentSum = 1300,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Statistics)]
        GetFinancialGoal,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Statistics)]
        GetActiveStatistic,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Statistics)]
        GetArchiveStatistic,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Statistics)]
        GetInventoryStatistic,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Statistics)]
        GetItemsCount,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Statistics)]
        GetUsersCountByCurrency,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Statistics)]
        GetItemsCountByGame,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Users)] GetUsers = 1400,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Users)] GetUsersCount,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Users)] GetUserInfo,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Users)] GetCurrentUserInfo,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Users)] GetCurrentUserGoalSum,

        ///<summary>GET request</summary>
        [ApiController(ApiControllers.Users)] GetHasAccessToAdminPanel,

        ///<summary>PUT request</summary>
        [ApiController(ApiControllers.Users)] PutGoalSum,

        ///<summary>DELETE request</summary>
        [ApiController(ApiControllers.Users)] DeleteUser
    }

    #endregion Enums

    #region Methods

    private static Dictionary<ApiMethods, ApiControllers> BuildControllerMap()
    {
        Dictionary<ApiMethods, ApiControllers> map = new();
        foreach (ApiMethods method in Enum.GetValues<ApiMethods>())
        {
            FieldInfo field = typeof(ApiMethods).GetField(method.ToString())!;
            ApiControllerAttribute attr = field.GetCustomAttribute<ApiControllerAttribute>()
                                          ?? throw new InvalidOperationException(
                                              $"ApiMethods.{method} is missing [ApiController] attribute.");
            map[method] = attr.Controller;
        }

        return map;
    }

    internal static ApiControllers GetController(ApiMethods method)
    {
        return ControllerMap.TryGetValue(method, out ApiControllers controller)
            ? controller
            : throw new ArgumentOutOfRangeException(nameof(method), method, "Unknown API method.");
    }

    #endregion Methods
}