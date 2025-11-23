namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;
public class DeleteChatMessageCommandRequestValidator : AbstractValidator<DeleteChatMessageCommandRequest>
{
    public DeleteChatMessageCommandRequestValidator()
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
    }
}
