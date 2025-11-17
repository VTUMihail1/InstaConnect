namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostPaginationQueryRequest(
    int Page,
    int PageSize);
