namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
public class AddChatMessageCommandRequestValidator : AbstractValidator<AddChatMessageCommandRequest>
{
    public AddChatMessageCommandRequestValidator()
    {
        RuleFor(r => r.ParticipantOneId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.ParticipantOneId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.ParticipantOneId.Length));

        RuleFor(r => r.ParticipantTwoId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.ParticipantTwoId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.ParticipantOneId.Length));

        RuleFor(r => r.Content)
            .NotEmpty()
            .WithMessage(ChatMessageErrorMessages.GetContentEmpty())
            .MinimumLength(ChatMessageConfigurations.ContentMinLength)
            .WithMessage(r => ChatMessageErrorMessages.GetContentTooShort(r.Content.Length))
            .MaximumLength(ChatMessageConfigurations.ContentMaxLength)
            .WithMessage(r => ChatMessageErrorMessages.GetContentTooLong(r.Content.Length));
    }
}
