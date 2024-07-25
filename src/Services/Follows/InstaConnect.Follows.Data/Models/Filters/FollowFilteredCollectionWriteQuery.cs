using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Follows.Data.Models.Filters;

public record FollowFilteredCollectionWriteQuery(
    string FollowerId,
    string FollowerName,
    string FollowingId,
    string FollowingName) : FilteredCollectionWriteQuery<Follow>(
        f => (string.IsNullOrEmpty(FollowerId) || f.FollowerId == FollowerId) &&
             (string.IsNullOrEmpty(FollowerName) || f.Follower!.UserName == FollowerName) &&
             (string.IsNullOrEmpty(FollowingId) || f.FollowingId == FollowingId) &&
             (string.IsNullOrEmpty(FollowingName) || f.Following!.UserName == FollowingName));
