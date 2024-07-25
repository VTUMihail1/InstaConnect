namespace InstaConnect.Follows.Business.Models.Follows;

public record FollowQueryViewModel(
    string Id,
    string FollowerId,
    string FollowerName,
    string? FollowerProfileImage,
    string FollowingId,
    string FollowingName,
    string? FollowingProfileImage);
