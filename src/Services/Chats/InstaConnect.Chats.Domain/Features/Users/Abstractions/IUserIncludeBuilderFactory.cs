using InstaConnect.Chats.Domain.Features.Users.Helpers;

namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface IUserIncludeBuilderFactory
{
	public UserIncludeBuilder Create();
}
