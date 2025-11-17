namespace InstaConnect.Identity.Application.Features.Users.Models;

public record UserPaginationQueryRequest(
    int Page,
    int PageSize);
