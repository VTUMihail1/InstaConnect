﻿namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;

public record FollowQueryResponse(
    string Id,
    string FollowerId,
    string FollowerName,
    string? FollowerProfileImage,
    string FollowingId,
    string FollowingName,
    string? FollowingProfileImage);
