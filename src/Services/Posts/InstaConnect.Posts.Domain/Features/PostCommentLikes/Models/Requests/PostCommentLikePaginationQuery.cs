namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikePaginationQuery(
    int Page,
    int PageSize);
