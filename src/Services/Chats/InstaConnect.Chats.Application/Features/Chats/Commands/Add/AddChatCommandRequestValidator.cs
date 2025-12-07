namespace InstaConnect.Chats.Application.Features.Chats.Commands.Add;
public class AddChatCommandRequestValidator : AbstractValidator<AddChatCommandRequest>
{
    public AddChatCommandRequestValidator()
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
