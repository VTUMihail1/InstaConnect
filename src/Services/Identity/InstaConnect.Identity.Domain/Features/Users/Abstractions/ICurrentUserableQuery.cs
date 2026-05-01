namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

public interface ICurrentUserableQuery
{
	public CurrentUserQuery Current { get; }
}
