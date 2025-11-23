using InstaConnect.Common.Application.Extensions;

namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
public class AddChatMessageCommandRequestValidator : AbstractValidator<AddChatMessageCommandRequest>
{
    public AddChatMessageCommandRequestValidator()
    {
        RuleFor(r => r.Id.ParticipantOneId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Id.ParticipantTwoId.Id)
            .NotEmptyWithMessage()
            .UserIdMinLengthWithMessage()
            .UserIdMaxLengthWithMessage();

        RuleFor(r => r.Content)
            .NotEmptyWithMessage()
            .ChatMessageContentMinLengthWithMessage()
            .ChatMessageContentMaxLengthWithMessage();
    }
}
