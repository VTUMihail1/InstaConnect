namespace InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

public record GetAllUsersApiResponse(
    ICollection<UserApiResponse> Users,
    int Page,
    int PageSize,
    long TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : ICollectionApiResponse;
