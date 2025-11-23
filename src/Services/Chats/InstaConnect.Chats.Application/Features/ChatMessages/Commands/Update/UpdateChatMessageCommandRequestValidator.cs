namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;
public class UpdateChatMessageCommandRequestValidator : AbstractValidator<UpdateChatMessageCommandRequest>
{
    public UpdateChatMessageCommandRequestValidator()
    {
        RuleFor(r => r.Id.Id.ParticipantOneId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Id.Id.ParticipantTwoId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Id.MessageId)
            .NotEmptyWithMessage()
            .ChatMessageIdMinLengthWithMessage()
            .ChatMessageIdMaxLengthWithMessage();

        RuleFor(r => r.Content)
            .NotEmptyWithMessage()
            .ChatMessageContentMinLengthWithMessage()
            .ChatMessageContentMaxLengthWithMessage();
    }
}
