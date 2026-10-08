using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Options;

public record ChatMessageOptions(
	string HubRoute) : IApplicationOptions
{
	public const string SectionName = "ChatMessageConfiguration";
}
