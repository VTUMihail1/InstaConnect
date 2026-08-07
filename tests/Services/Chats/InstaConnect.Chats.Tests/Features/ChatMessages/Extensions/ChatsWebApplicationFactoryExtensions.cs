using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Options;
using InstaConnect.Chats.Tests.Features.Common.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;

public static class ChatsWebApplicationFactoryExtensions
{
	extension(ChatsWebApplicationFactory webApplicationFactory)
	{
		public IChatMessageNotificationClient CreateMessageNotificationClient(UserId participantTwoId)
		{
			var hubRoute = webApplicationFactory.Services
				.GetRequiredService<IOptions<ChatMessageOptions>>()
				.Value
				.HubRoute;

			var connection = webApplicationFactory.CreateHubConnection(participantTwoId.Id, hubRoute.TrimStartSlash());

			return new ChatMessageNotificationClient(connection);
		}
	}
}
