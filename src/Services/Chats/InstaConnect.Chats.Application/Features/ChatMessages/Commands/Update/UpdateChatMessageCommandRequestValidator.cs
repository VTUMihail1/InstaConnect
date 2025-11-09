namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;
public class UpdateChatMessageCommandRequestValidator : AbstractValidator<UpdateChatMessageCommandRequest>
{
    public UpdateChatMessageCommandRequestValidator()
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

        RuleFor(r => r.MessageId)
            .NotEmpty()
            .WithMessage(ChatMessageErrorMessages.GetIdEmpty())
            .MinimumLength(ChatMessageConfigurations.IdMinLength)
            .WithMessage(r => ChatMessageErrorMessages.GetIdTooShort(r.MessageId.Length))
            .MaximumLength(ChatMessageConfigurations.IdMaxLength)
            .WithMessage(r => ChatMessageErrorMessages.GetIdTooLong(r.MessageId.Length));

        RuleFor(r => r.Content)
            .NotEmpty()
            .WithMessage(ChatMessageErrorMessages.GetContentEmpty())
            .MinimumLength(ChatMessageConfigurations.ContentMinLength)
            .WithMessage(r => ChatMessageErrorMessages.GetContentTooShort(r.Content.Length))
            .MaximumLength(ChatMessageConfigurations.ContentMaxLength)
            .WithMessage(r => ChatMessageErrorMessages.GetContentTooLong(r.Content.Length));
    }
}
