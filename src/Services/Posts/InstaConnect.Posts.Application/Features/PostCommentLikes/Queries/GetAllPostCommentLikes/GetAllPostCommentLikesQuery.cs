using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Models.Filters;
using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;

public record GetAllPostCommentLikesQuery(
    string UserId,
    string UserName,
    string PostCommentId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<PostCommentLikePaginationQueryViewModel>;
