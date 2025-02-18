namespace InstaConnect.Identity.Application.Features.Users.Queries.GetById;

public record GetUserByIdQuery(string Id) : IQuery<UserQueryViewModel>;
