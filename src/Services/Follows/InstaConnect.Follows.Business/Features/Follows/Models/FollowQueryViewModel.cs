namespace InstaConnect.Follows.Business.Features.Follows.Models;

public record FollowQueryViewModel(
    string Id,
    string FollowerId,
    string FollowerName,
    string? FollowerProfileImage,
    string FollowingId,
    string FollowingName,
    string? FollowingProfileImage);
