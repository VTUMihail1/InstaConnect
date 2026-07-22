using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Chats.Tests.Features.Users.Utilities;

public static class UserReference
{
	extension(User? user)
	{
		public User? SetChats()
		{
			user?.Chats.ForEach(e => e.SetParticipantOne().SetParticipantTwo());

			return user;
		}

		public User? SetChatMessages()
		{
			user?.ChatMessages.ForEach(e => e.AddSender(user).SetChat());

			return user;
		}
	}
}
