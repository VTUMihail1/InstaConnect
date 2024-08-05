using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Follows.Data.Features.Follows.Models.Filters;

public record FollowFilteredCollectionReadQuery(
    string FollowerId,
    string FollowerName,
    string FollowingId,
    string FollowingName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : FilteredCollectionReadQuery<Follow>(
        f => (string.IsNullOrEmpty(FollowerId) || f.FollowerId.Equals(FollowerId)) &&
             (string.IsNullOrEmpty(FollowerName) || f.Follower!.UserName.StartsWith(FollowerName)) &&
             (string.IsNullOrEmpty(FollowingId) || f.FollowingId.Equals(FollowingId)) &&
             (string.IsNullOrEmpty(FollowingName) || f.Following!.UserName.StartsWith(FollowingName)),
        SortOrder,
        SortPropertyName,
        Page,
        PageSize);
