using InstaConnect.Follows.Business.Models.Follows;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFilteredFollows;

public record GetAllFilteredFollowsQuery(
    string FollowerId,
    string FollowerName,
    string FollowingId,
    string FollowingName,
    SortOrder SortOrder, 
    string SortPropertyName, 
    int Page, 
    int PageSize) 
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<FollowPaginationQueryViewModel>;
