namespace InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;

public record GetUserDetailsByIdQueryRequest(string Id) : IQueryRequest<GetUserDetailsByIdQueryResponse>;
