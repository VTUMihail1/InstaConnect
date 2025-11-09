namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentPaginationQuery(
    int Page,
    int PageSize);
