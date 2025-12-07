namespace InstaConnect.Identity.Domain.Features.Users.Models.Responses;
public record UserCollection(
    ICollection<User> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
