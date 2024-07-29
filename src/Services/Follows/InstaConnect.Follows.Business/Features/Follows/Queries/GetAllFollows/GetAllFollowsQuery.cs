using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;

public record GetAllFollowsQuery(SortOrder SortOrder, string SortPropertyName, int Page, int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<FollowPaginationQueryViewModel>;
