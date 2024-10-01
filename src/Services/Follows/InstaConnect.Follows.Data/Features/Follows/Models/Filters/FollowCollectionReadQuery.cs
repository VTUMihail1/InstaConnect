using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Follows.Data.Features.Follows.Models.Filters;

public record FollowCollectionReadQuery(
    string FollowerId,
    string FollowerName,
    string FollowingId,
    string FollowingName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize);
