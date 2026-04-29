namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatFactory
{
	public Chat Create(UserId participantOneId, UserId participantTwoId);
}
