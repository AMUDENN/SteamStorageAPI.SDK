﻿using SteamStorageAPI.SDK.ApiEntities.Tools;
// ReSharper disable NotAccessedPositionalProperty.Global

namespace SteamStorageAPI.SDK.ApiEntities;

public static class ArchiveGroups
{
    #region Enums

    public enum ArchiveGroupOrderName
    {
        Title,
        Count,
        BuySum,
        SoldSum,
        Change
    }

    #endregion Enums

    #region Records

    public record ArchiveGroupResponse(
        int Id,
        string Title,
        string? Description,
        string Colour,
        int Count,
        decimal BuySum,
        decimal SoldSum,
        double Change,
        DateTime DateCreation) : Response;

    public record ArchiveGroupsResponse(
        int Count,
        IEnumerable<ArchiveGroupResponse>? ArchiveGroups) : Response;
    
    public record ArchiveGroupsGameCountResponse(
        string GameTitle,
        double Percentage,
        int Count) : Response;

    public record ArchiveGroupsGameBuySumResponse(
        string GameTitle,
        double Percentage,
        decimal BuySum) : Response;
        
    public record ArchiveGroupsGameSoldSumResponse(
        string GameTitle,
        double Percentage,
        decimal SoldSum) : Response;

    public record ArchiveGroupsStatisticResponse(
        int ArchivesCount,
        decimal BuySum,
        decimal SoldSum,
        IEnumerable<ArchiveGroupsGameCountResponse>? GameCount,
        IEnumerable<ArchiveGroupsGameBuySumResponse>? GameBuySum,
        IEnumerable<ArchiveGroupsGameSoldSumResponse>? GameSoldSum) : Response;

    public record ArchiveGroupsCountResponse(
        int Count) : Response;

    public record GetArchiveGroupsRequest(
        ArchiveGroupOrderName? OrderName,
        bool? IsAscending) : Request;

    public record PostArchiveGroupRequest(
        string Title,
        string? Description,
        string? Colour) : Request;

    public record PutArchiveGroupRequest(
        int GroupId,
        string Title,
        string? Description,
        string? Colour) : Request;

    public record DeleteArchiveGroupRequest(
        int GroupId) : Request;

    #endregion Records
}
