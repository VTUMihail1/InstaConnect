namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
public class AddChatMessageCommandRequestValidator : AbstractValidator<AddChatMessageCommandRequest>
{
    public AddChatMessageCommandRequestValidator()
    {
        RuleFor(r => r.ParticipantOneId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.ParticipantTwoId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.SenderId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Content)
            .NotEmptyWithMessage()
            .ChatMessageContentMinLengthWithMessage()
            .ChatMessageContentMaxLengthWithMessage();
    }
}
