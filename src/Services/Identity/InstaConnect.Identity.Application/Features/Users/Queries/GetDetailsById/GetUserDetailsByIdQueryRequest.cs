namespace InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;

public record GetUserDetailsByIdQueryRequest(UserIdPayload Id) : IQueryRequest<GetUserDetailsByIdQueryResponse>;
