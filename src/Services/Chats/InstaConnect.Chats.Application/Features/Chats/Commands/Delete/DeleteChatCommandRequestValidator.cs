namespace InstaConnect.Chats.Application.Features.Chats.Commands.Delete;
public class DeleteChatCommandRequestValidator : AbstractValidator<DeleteChatCommandRequest>
{
    public DeleteChatCommandRequestValidator()
    {
        RuleFor(r => r.Id.ParticipantOneId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Id.ParticipantTwoId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
