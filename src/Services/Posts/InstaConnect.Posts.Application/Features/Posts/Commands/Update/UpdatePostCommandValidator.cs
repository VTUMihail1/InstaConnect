namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;
public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
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

        RuleFor(c => c.Title)
            .NotEmpty()
            .WithMessage(PostErrorMessages.TitleEmpty)
            .MinimumLength(PostConfigurations.TitleMinLength)
            .WithMessage(PostErrorMessages.TitleTooShort)
            .MaximumLength(PostConfigurations.TitleMaxLength)
            .WithMessage(PostErrorMessages.TitleTooLong);

        RuleFor(c => c.Content)
            .NotEmpty()
            .WithMessage(PostErrorMessages.ContentEmpty)
            .MinimumLength(PostConfigurations.ContentMinLength)
            .WithMessage(PostErrorMessages.ContentTooShort)
            .MaximumLength(PostConfigurations.ContentMaxLength)
            .WithMessage(PostErrorMessages.ContentTooLong);
    }
}
