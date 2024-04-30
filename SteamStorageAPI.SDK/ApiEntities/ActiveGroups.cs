﻿using SteamStorageAPI.SDK.ApiEntities.Tools;
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable UnusedType.Global

namespace SteamStorageAPI.SDK.ApiEntities;

public static class ActiveGroups
{
    #region Enums

    public enum ActiveGroupOrderName
    {
        Title,
        Count,
        BuySum,
        CurrentSum,
        Change
    }

    #endregion Enums

    #region Records

    public record ActiveGroupResponse(
        int Id,
        string Title,
        string? Description,
        string Colour,
        decimal? GoalSum,
        double? GoalSumCompletion,
        int Count,
        decimal BuySum,
        decimal CurrentSum,
        double Change,
        DateTime DateCreation) : Response;

    public record ActiveGroupsResponse(
        int Count,
        IEnumerable<ActiveGroupResponse>? ActiveGroups) : Response;
    
    public record ActiveGroupsGameCountResponse(
        string GameTitle,
        double Percentage,
        int Count) : Response;

    public record ActiveGroupsGameInvestmentSumResponse(
        string GameTitle,
        double Percentage,
        decimal InvestmentSum) : Response;
        
    public record ActiveGroupsGameCurrentSumResponse(
        string GameTitle,
        double Percentage,
        decimal CurrentSum) : Response;

    public record ActiveGroupsStatisticResponse(
        int ActivesCount,
        decimal InvestmentSum,
        decimal CurrentSum,
        IEnumerable<ActiveGroupsGameCountResponse>? GameCount,
        IEnumerable<ActiveGroupsGameInvestmentSumResponse>? GameInvestmentSum,
        IEnumerable<ActiveGroupsGameCurrentSumResponse>? GameCurrentSum) : Response;

    public record ActiveGroupDynamicResponse(
        int Id,
        DateTime DateUpdate,
        decimal Sum) : Response;

    public record ActiveGroupDynamicStatsResponse(
        double ChangePeriod,
        IEnumerable<ActiveGroupDynamicResponse>? Dynamic) : Response;

    public record ActiveGroupsCountResponse(
        int Count) : Response;

    public record GetActiveGroupsRequest(
        ActiveGroupOrderName? OrderName,
        bool? IsAscending) : Request;

    public record GetActiveGroupDynamicRequest(
        int GroupId,
        DateTime StartDate,
        DateTime EndDate) : Request;

    public record PostActiveGroupRequest(
        string Title,
        string? Description,
        string? Colour,
        decimal? GoalSum) : Request;
    
    public record PutActiveGroupRequest(
        int GroupId,
        string Title,
        string? Description,
        string? Colour,
        decimal? GoalSum) : Request;
    
    public record DeleteActiveGroupRequest(
        int GroupId) : Request;

    #endregion Records
}
