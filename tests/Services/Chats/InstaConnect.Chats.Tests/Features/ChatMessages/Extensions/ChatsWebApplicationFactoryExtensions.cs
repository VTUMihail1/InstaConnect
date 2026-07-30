using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Chats.Presentation.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Common.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;

public static class ChatsWebApplicationFactoryExtensions
{
	extension(ChatsWebApplicationFactory webApplicationFactory)
	{
		public IChatMessageNotificationClient CreateMessageNotificationClient(UserId participantTwoId)
		{
			var connection = webApplicationFactory.CreateHubConnection(participantTwoId.Id, ChatMessageRoutes.Hub.TrimStartSlash());

			return new ChatMessageNotificationClient(connection);
		}
	}
}
