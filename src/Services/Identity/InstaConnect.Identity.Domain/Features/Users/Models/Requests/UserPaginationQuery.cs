namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record UserPaginationQuery(
    int Page,
    int PageSize);
