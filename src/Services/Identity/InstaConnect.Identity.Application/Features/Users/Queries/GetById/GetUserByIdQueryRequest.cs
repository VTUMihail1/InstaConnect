using InstaConnect.Users.Application.Features.Users.Queries.GetAll;

namespace InstaConnect.Users.Application.Features.Users.Queries.GetById;

public record GetUserByIdQueryRequest(string Id) : IQueryRequest<GetUserByIdQueryResponse>;
