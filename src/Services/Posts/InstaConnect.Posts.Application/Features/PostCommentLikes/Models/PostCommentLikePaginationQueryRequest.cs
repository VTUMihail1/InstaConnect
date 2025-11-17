namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikePaginationQueryRequest(
    int Page,
    int PageSize);
