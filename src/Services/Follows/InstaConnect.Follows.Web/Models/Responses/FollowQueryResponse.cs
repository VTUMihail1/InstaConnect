namespace InstaConnect.Follows.Read.Web.Models.Responses;

public record FollowQueryResponse(
    string Id,
    string FollowerId,
    string FollowerName,
    string? FollowerProfileImage,
    string FollowingId,
    string FollowingName,
    string? FollowingProfileImage);
