using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Options;

public class ChatMessageOptions : IApplicationOptions
{
	public const string SectionName = "ChatMessageConfiguration";

	[Required]
	public string HubRoute { get; set; } = string.Empty;
}
