using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Posts.Business.Features.Posts.Queries.GetAllPosts;

public record GetAllPostsQuery(
    string UserId,
    string UserName,
    string Title,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<PostPaginationQueryViewModel>;
