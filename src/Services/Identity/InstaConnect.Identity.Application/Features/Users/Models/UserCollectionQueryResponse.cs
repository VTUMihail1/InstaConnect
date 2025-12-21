namespace InstaConnect.Identity.Application.Features.Users.Models;

public record UserCollectionQueryResponse(
    ICollection<UserQueryResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : ICollectionQueryResponse;
