using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Chats.Tests.Features.Users.Utilities;

public static class UserReference
{
	extension(User? user)
	{
		public User? SetChats()
		{
			user?.Chats.ForEach(e =>
			{
				if (e.Id.ParticipantOneId.Is(user!.Id))
				{
					e.AddParticipantOne(user);
				}
				else
				{
					e.AddParticipantTwo(user);
				}
			});

			return user;
		}

		public User? SetChatMessages()
		{
			user?.ChatMessages.ForEach(e => e.AddSender(user));

			return user;
		}
	}
}
