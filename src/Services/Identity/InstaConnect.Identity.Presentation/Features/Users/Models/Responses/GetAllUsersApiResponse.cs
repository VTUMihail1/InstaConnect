namespace InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

public record GetAllUsersApiResponse(
    ICollection<UserApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
