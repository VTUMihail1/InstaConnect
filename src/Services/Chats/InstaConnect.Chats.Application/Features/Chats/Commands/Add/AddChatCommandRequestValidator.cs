namespace InstaConnect.Chats.Application.Features.Chats.Commands.Add;
public class AddChatCommandRequestValidator : AbstractValidator<AddChatCommandRequest>
{
    public AddChatCommandRequestValidator()
    {
        RuleFor(r => r.ParticipantOneId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.ParticipantTwoId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();
    }
}
