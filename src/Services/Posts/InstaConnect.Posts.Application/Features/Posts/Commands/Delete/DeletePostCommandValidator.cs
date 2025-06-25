namespace InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
{
    public DeletePostCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage(PostErrorMessages.IdEmpty)
            .MinimumLength(PostConfigurations.IdMinLength)
            .WithMessage(PostErrorMessages.IdTooShort)
            .MaximumLength(PostConfigurations.IdMaxLength)
            .WithMessage(PostErrorMessages.IdTooLong);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.IdEmpty)
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(UserErrorMessages.IdTooShort)
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(UserErrorMessages.IdTooLong);
    }
}
