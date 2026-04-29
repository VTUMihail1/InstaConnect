namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;

public class DeleteChatMessageCommandRequestValidator : AbstractValidator<DeleteChatMessageCommandRequest>
{
	public DeleteChatMessageCommandRequestValidator()
	{
		RuleFor(r => r.ParticipantOneId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(r => r.ParticipantTwoId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(r => r.MessageId)
			.NotEmptyWithMessage()
			.ChatMessageIdMinLengthWithMessage()
			.ChatMessageIdMaxLengthWithMessage();
	}
}
