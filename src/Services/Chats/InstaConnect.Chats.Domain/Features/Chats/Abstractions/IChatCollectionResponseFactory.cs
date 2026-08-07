namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatCollectionResponseFactory
{
	public ChatCollectionResponse Create(UserResponse participantOne, ICollection<ChatResponse> chats, long totalCount, ChatsPaginationQuery pagination);
}
