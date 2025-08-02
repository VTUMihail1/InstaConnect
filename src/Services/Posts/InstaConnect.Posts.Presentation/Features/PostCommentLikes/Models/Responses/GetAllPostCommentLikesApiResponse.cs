using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Models;

namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;

public record GetAllPostCommentLikesApiResponse(
    ICollection<PostCommentLikeApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
