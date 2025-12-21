using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

public record GetAllPostCommentLikesQueryRequest(
    string Id,
    string CommentId,
    string UserName,
    CommonSortOrder SortOrder,
    PostCommentLikeSortProperty SortProperty,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllPostCommentLikesQueryResponse>, ISortableQueryRequest<PostCommentLikeSortProperty>, IPaginatableQueryRequest;
