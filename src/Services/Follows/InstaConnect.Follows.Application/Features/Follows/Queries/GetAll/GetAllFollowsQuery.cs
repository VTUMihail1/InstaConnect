using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Models.Filters;
using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllFollows;

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
