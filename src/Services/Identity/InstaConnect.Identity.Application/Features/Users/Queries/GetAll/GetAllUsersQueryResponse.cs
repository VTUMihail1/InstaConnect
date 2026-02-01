namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

public record GetAllUsersQueryResponse(
    ICollection<UserQueryResponse> Users,
    int Page,
    int PageSize,
    long TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : ICollectionQueryResponse;
