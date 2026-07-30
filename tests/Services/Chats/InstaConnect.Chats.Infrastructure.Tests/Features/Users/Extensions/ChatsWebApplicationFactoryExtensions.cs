using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Abstractions;
using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Helpers;
using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Users.Extensions;

public static class ChatsWebApplicationFactoryExtensions
{
	extension(ChatsWebApplicationFactory webApplicationFactory)
	{
		public IUserEventClient CreateUserEventClient()
		{
			var eventHarness = webApplicationFactory.Services.GetEventHarness();

			return new UserEventClient(eventHarness);
		}
	}
}
