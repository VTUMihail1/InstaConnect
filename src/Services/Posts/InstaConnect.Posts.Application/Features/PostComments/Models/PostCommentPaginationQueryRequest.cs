namespace InstaConnect.Posts.Application.Features.PostComments.Models;

public record PostCommentPaginationQueryRequest(
    int Page,
    int PageSize);
