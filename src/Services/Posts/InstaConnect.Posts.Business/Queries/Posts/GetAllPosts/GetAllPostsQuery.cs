using InstaConnect.Posts.Business.Models.Post;
using InstaConnect.Posts.Business.Models.PostCommentLike;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Posts.Business.Queries.Posts.GetAllPosts;

public record GetAllPostsQuery(
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<PostPaginationQueryViewModel>;
