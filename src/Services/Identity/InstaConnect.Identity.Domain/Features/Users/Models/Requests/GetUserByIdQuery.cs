namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record GetUserByIdQuery(
	UserId Id,
	CurrentUserQuery Current) : ICurrentUserableQuery;
