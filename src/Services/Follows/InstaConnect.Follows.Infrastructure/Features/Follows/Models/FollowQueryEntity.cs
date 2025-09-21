namespace InstaConnect.Follows.Infrastructure.Features.Follows.Models;

public record FollowQueryEntity(
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt,
        string FollowerId,
        string FollowerName,
        string FollowerEmail,
        string FollowerFirstName,
        string FollowerLastName,
        string FollowerProfileImage,
        DateTimeOffset FollowerCreatedAt,
        DateTimeOffset FollowerUpdatedAt,
        string FollowingId,
        string FollowingName,
        string FollowingEmail,
        string FollowingFirstName,
        string FollowingLastName,
        string FollowingProfileImage,
        DateTimeOffset FollowingCreatedAt,
        DateTimeOffset FollowingUpdatedAt);
