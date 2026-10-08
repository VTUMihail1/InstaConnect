using FluentValidation;

using InstaConnect.Common.Domain.Features.Validations.Extensions;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Options;

public class ChatMessageOptionsValidator : AbstractValidator<ChatMessageOptions>
{
	public ChatMessageOptionsValidator()
	{
		RuleFor(o => o.HubRoute)
			.NotEmptyWithMessage();
	}
}
