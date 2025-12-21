namespace InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

public record UserCollectionApiResponse(
    ICollection<UserApiResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : ICollectionApiResponse;
