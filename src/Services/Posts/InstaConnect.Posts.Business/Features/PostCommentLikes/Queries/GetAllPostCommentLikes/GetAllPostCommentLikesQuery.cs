using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllFilteredPostCommentLikes;

public record GetAllPostCommentLikesQuery(
    string UserId,
    string UserName,
    string PostCommentId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<PostCommentLikePaginationQueryViewModel>;
