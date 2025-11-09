namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UserPaginationQuery(
    int Page,
    int PageSize);
