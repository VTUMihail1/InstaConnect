namespace InstaConnect.Messages.Application.Features.Messages.Commands.Delete;

public class DeleteMessageCommandValidator : AbstractValidator<DeleteMessageCommand>
{
    public DeleteMessageCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(MessageConfigurations.IdMinLength)
            .MaximumLength(MessageConfigurations.IdMaxLength);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);
    }
}
