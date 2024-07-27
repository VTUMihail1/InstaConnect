using InstaConnect.Posts.Business.Models.Post;
using InstaConnect.Posts.Business.Models.PostLike;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts;

public record GetAllFilteredPostsQuery(
    string UserId,
    string UserName,
    string Title,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<PostPaginationQueryViewModel>;
