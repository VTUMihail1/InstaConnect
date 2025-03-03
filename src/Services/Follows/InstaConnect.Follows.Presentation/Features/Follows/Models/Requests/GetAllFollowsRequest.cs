﻿namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record GetAllFollowsRequest(
    [FromQuery(Name = "followerId")] string FollowerId = "",
    [FromQuery(Name = "followerName")] string FollowerName = "",
    [FromQuery(Name = "followingId")] string FollowingId = "",
    [FromQuery(Name = "followingName")] string FollowingName = "",
    [FromQuery(Name = "sortOrder")] SortOrder SortOrder = SortOrder.ASC,
    [FromQuery(Name = "sortPropertyName")] string SortPropertyName = "CreatedAt",
    [FromQuery(Name = "page")] int Page = 1,
    [FromQuery(Name = "pageSize")] int PageSize = 20
);
