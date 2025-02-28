using InstaConnect.Common.Application.Models.Filters;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

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
