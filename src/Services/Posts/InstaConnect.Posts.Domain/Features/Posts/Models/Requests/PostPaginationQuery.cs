namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostPaginationQuery(
    int Page,
    int PageSize);
