namespace InstaConnect.Chats.Application.Features.Chats.Commands.Delete;
public class DeleteChatCommandRequestValidator : AbstractValidator<DeleteChatCommandRequest>
{
    public DeleteChatCommandRequestValidator()
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
    }
}
