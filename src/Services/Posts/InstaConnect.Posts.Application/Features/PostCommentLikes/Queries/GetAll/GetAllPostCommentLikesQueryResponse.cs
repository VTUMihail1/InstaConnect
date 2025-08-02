using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Models;

namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;

public record GetAllPostCommentLikesQueryResponse(
    ICollection<PostCommentLikeQueryResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
