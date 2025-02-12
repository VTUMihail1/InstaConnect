namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowQueryViewModel(
    string Id,
    string FollowerId,
    string FollowerName,
    string? FollowerProfileImage,
    string FollowingId,
    string FollowingName,
    string? FollowingProfileImage);
