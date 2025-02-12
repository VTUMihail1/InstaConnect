using InstaConnect.Identity.Application.Features.Users.Models;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

public record UserPaginationQueryResponse(
    ICollection<UserQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
