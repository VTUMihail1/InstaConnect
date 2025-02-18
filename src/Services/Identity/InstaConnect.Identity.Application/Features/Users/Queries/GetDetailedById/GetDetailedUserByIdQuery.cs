namespace InstaConnect.Identity.Application.Features.Users.Queries.GetDetailedById;

public record GetDetailedUserByIdQuery(string Id) : IQuery<UserDetailedQueryViewModel>;
