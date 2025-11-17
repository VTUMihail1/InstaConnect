namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikePaginationQueryRequest(
    int Page,
    int PageSize);
