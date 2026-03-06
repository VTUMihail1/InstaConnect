namespace InstaConnect.Chats.Application.Features.Chats.Commands.Delete;

public class DeleteChatCommandRequestValidator : AbstractValidator<DeleteChatCommandRequest>
{
    public DeleteChatCommandRequestValidator()
    {
        RuleFor(r => r.ParticipantOneId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.ParticipantTwoId)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
