namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;
public class UpdatePostCommandRequestValidator : AbstractValidator<UpdatePostCommandRequest>
{
    public UpdatePostCommandRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetIdEmpty())
            .MinimumLength(PostConfigurations.IdMinLength)
            .WithMessage(r => PostErrorMessages.GetIdTooShort(r.Id.Length))
            .MaximumLength(PostConfigurations.IdMaxLength)
            .WithMessage(r => PostErrorMessages.GetIdTooLong(r.Id.Length));

        RuleFor(r => r.UserId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.UserId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.UserId.Length));

        RuleFor(r => r.Title)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetTitleEmpty())
            .MinimumLength(PostConfigurations.TitleMinLength)
            .WithMessage(r => PostErrorMessages.GetTitleTooShort(r.Title.Length))
            .MaximumLength(PostConfigurations.TitleMaxLength)
            .WithMessage(r => PostErrorMessages.GetTitleTooLong(r.Title.Length));

        RuleFor(c => c.Content)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetContentEmpty())
            .MinimumLength(PostConfigurations.ContentMinLength)
            .WithMessage(r => PostErrorMessages.GetContentTooShort(r.Content.Length))
            .MaximumLength(PostConfigurations.ContentMaxLength)
            .WithMessage(r => PostErrorMessages.GetContentTooLong(r.Content.Length));
    }
}
