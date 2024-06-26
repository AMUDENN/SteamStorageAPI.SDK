﻿// ReSharper disable UnusedMember.Global

namespace SteamStorageAPI.SDK.Utilities;

public static class ApiConstants
{
    #region Constants

    public const string CLIENT_NAME = "MainClient";
    public const string HOST_NAME = "steamstorage.ru";
    
    internal const string SERVER_ADDRESS = "https://steamstorage.ru/";
    internal const string TOKEN_HUB_ENDPOINT = "https://steamstorage.ru/token/token-hub";
    
    internal const string API_DATE_FORMAT = "MM.dd.yyyy";

    internal const string TOKEN_METHOD_NAME = "Token";
    internal const string JOIN_GROUP_METHOD_NAME = "JoinGroup";

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
        Pages,
        Roles,
        Skins,
        Statistics,
        Users
    }

    public enum ApiMethods
    {
        ///<summary>GET request</summary>
        GetActiveGroupInfo = 100,
        ///<summary>GET request</summary>
        GetActiveGroups,
        ///<summary>GET request</summary>
        GetActiveGroupsStatistic,
        ///<summary>GET request</summary>
        GetActiveGroupDynamics,
        ///<summary>GET request</summary>
        GetActiveGroupsCount,
        ///<summary>POST request</summary>
        PostActiveGroup,
        ///<summary>PUT request</summary>
        PutActiveGroup,
        ///<summary>DELETE request</summary>
        DeleteActiveGroup,

        ///<summary>GET request</summary>
        GetActiveInfo = 200,
        ///<summary>GET request</summary>
        GetActives,
        ///<summary>GET request</summary>
        GetActivesStatistic,
        ///<summary>GET request</summary>
        GetActivesPagesCount,
        ///<summary>GET request</summary>
        GetActivesCount,
        ///<summary>POST request</summary>
        PostActive,
        ///<summary>PUT request</summary>
        PutActive,
        ///<summary>PUT request</summary>
        SoldActive,
        ///<summary>DELETE request</summary>
        DeleteActive,

        ///<summary>GET request</summary>
        GetArchiveGroupInfo = 300,
        ///<summary>GET request</summary>
        GetArchiveGroups,
        ///<summary>GET request</summary>
        GetArchiveGroupsStatistic,
        ///<summary>GET request</summary>
        GetArchiveGroupsCount,
        ///<summary>POST request</summary>
        PostArchiveGroup,
        ///<summary>PUT request</summary>
        PutArchiveGroup,
        ///<summary>DELETE request</summary>
        DeleteArchiveGroup,

        ///<summary>GET request</summary>
        GetArchiveInfo = 400,
        ///<summary>GET request</summary>
        GetArchives,
        ///<summary>GET request</summary>
        GetArchivesStatistic,
        ///<summary>GET request</summary>
        GetArchivesPagesCount,
        ///<summary>GET request</summary>
        GetArchivesCount,
        ///<summary>POST request</summary>
        PostArchive,
        ///<summary>PUT request</summary>
        PutArchive,
        ///<summary>DELETE request</summary>
        DeleteArchive,

        ///<summary>GET request</summary>
        GetAuthUrl = 500,

        ///<summary>GET request</summary>
        GetCurrencies = 600,
        ///<summary>GET request</summary>
        GetCurrency,
        ///<summary>GET request</summary>
        GetCurrentCurrency,
        ///<summary>POST request</summary>
        PostCurrency,
        ///<summary>PUT request</summary>
        PutCurrencyInfo,
        ///<summary>PUT request</summary>
        SetCurrency,
        ///<summary>DELETE request</summary>
        DeleteCurrency,
        
        ///<summary>GET request</summary>
        GetExcelFile = 700,

        ///<summary>GET request</summary>
        GetGames = 800,
        ///<summary>POST request</summary>
        PostGame,
        ///<summary>PUT request</summary>
        PutGameInfo,
        ///<summary>DELETE request</summary>
        DeleteGame,

        ///<summary>GET request</summary>
        GetInventory = 900,
        ///<summary>GET request</summary>
        GetInventoriesStatistic,
        ///<summary>GET request</summary>
        GetInventoryPagesCount,
        ///<summary>GET request</summary>
        GetSavedInventoriesCount,
        ///<summary>POST request</summary>
        RefreshInventory,

        ///<summary>GET request</summary>
        GetPages = 1000,
        ///<summary>GET request</summary>
        GetCurrentStartPage,
        ///<summary>PUT request</summary>
        SetStartPage,
        
        ///<summary>GET request</summary>
        GetRoles = 1100,
        ///<summary>PUT request</summary>
        SetRole,

        ///<summary>GET request</summary>
        GetSkinInfo = 1200,
        ///<summary>GET request</summary>
        GetBaseSkins,
        ///<summary>GET request</summary>
        GetSkins,
        ///<summary>GET request</summary>
        GetSkinDynamics,
        ///<summary>GET request</summary>
        GetSkinPagesCount,
        ///<summary>GET request</summary>
        GetSteamSkinsCount,
        ///<summary>GET request</summary>
        GetSavedSkinsCount,
        ///<summary>POST request</summary>
        PostSkin,
        ///<summary>PUT request</summary>
        SetMarkedSkin,
        ///<summary>DELETE request</summary>
        DeleteMarkedSkin,

        ///<summary>GET request</summary>
        GetInvestmentSum = 1300,
        ///<summary>GET request</summary>
        GetFinancialGoal,
        ///<summary>GET request</summary>
        GetActiveStatistic,
        ///<summary>GET request</summary>
        GetArchiveStatistic,
        ///<summary>GET request</summary>
        GetInventoryStatistic,
        ///<summary>GET request</summary>
        GetItemsCount,

        ///<summary>GET request</summary>
        GetUsers = 1400,
        ///<summary>GET request</summary>
        GetUsersCount,
        ///<summary>GET request</summary>
        GetUserInfo,
        ///<summary>GET request</summary>
        GetCurrentUserInfo,
        ///<summary>GET request</summary>
        GetCurrentUserGoalSum,
        ///<summary>GET request</summary>
        GetHasAccessToAdminPanel,
        ///<summary>PUT request</summary>
        PutGoalSum,
        ///<summary>DELETE request</summary>
        DeleteUser
    }

    #endregion Enums
}
