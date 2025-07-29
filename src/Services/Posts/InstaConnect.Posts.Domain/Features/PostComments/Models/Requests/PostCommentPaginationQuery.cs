namespace InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

public record PostCommentPaginationQuery(
    int Page,
    int PageSize);
