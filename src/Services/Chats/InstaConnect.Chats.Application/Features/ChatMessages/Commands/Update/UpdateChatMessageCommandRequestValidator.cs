namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;

public class UpdateChatMessageCommandRequestValidator : AbstractValidator<UpdateChatMessageCommandRequest>
{
	public UpdateChatMessageCommandRequestValidator()
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

		RuleFor(r => r.Content)
			.NotEmptyWithMessage()
			.ChatMessageContentMinLengthWithMessage()
			.ChatMessageContentMaxLengthWithMessage();
	}
}
