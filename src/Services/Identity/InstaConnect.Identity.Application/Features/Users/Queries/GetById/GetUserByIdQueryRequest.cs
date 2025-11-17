namespace InstaConnect.Identity.Application.Features.Users.Queries.GetById;

public record GetUserByIdQueryRequest(UserIdPayload Id) : IQueryRequest<GetUserByIdQueryResponse>;
