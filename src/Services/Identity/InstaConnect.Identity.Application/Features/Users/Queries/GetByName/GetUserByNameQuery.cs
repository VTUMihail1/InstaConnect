namespace InstaConnect.Identity.Application.Features.Users.Queries.GetByName;

public record GetUserByNameQuery(string UserName) : IQuery<UserQueryViewModel>;
