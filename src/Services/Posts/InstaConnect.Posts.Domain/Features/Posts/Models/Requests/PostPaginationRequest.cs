namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostPaginationRequest(
    int Page,
    int PageSize);
