using InstaConnect.Chats.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

internal interface IChatCollectionResponseFactory
{
	public ChatCollectionResponse Create(UserResponse participantOne, ICollection<ChatResponse> chats, long totalCount, ChatsPaginationQuery pagination);
}
