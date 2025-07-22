using InstaConnect.Common.Application.Models.Filters;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

public record GetAllPostCommentLikesQuery(
    string PostId,
    string PostCommentId,
    string UserId,
    string UserName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQueryRequest<PostCommentLikePaginationQueryViewModel>;
