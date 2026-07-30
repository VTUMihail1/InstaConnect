using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Options;
using InstaConnect.Chats.Tests.Features.Common.Utilities;

using InstaConnect.Common.Domain.Features.Common.Extensions;

using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Chats.Tests.Features.Common.Extensions;

public static class WebHostBuilderExtensions
{
	extension(IWebHostBuilder webHostBuilder)
	{
		public void UpdateChatMessageConfiguration()
		{
			webHostBuilder.UseSetting(
				ChatMessageOptions.SectionName.FormatCurrentCultureSectionKey(nameof(ChatMessageOptions.HubRoute)),
				ChatsMockValues.ChatMessageHubRoute);
		}
	}
}
