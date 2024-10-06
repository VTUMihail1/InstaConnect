using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;

public record GetAllFollowsQuery(
    string FollowerId,
    string FollowerName,
    string FollowingId,
    string FollowingName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<FollowPaginationQueryViewModel>;
