using InstaConnect.Identity.Domain.Features.Users.Helpers;

namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

public interface IUserIncludeBuilderFactory
{
	public UserIncludeBuilder Create();
}
