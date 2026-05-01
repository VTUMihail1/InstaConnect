using InstaConnect.Chats.Domain.Features.Users.Helpers;

namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface IParticipantTwoIncludeBuilderFactory
{
	public ParticipantTwoIncludeBuilder Create();
}
