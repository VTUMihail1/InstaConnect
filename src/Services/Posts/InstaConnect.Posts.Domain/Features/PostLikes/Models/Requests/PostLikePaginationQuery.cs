namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikePaginationQuery(
    int Page,
    int PageSize);
