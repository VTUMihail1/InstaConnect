using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface IUserIncludeDescriptorFactory
{
	public ChatsIncludeDescriptor CreateChats();

	public ChatsIncludeDescriptor CreateChatMessages();
}
