namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;
public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {
        RuleFor(r => r.Id)
            .MinimumLength(PostConfigurations.IdMinLength)
            .WithMessage(r => PostErrorMessages.GetIdTooShort(r.Id))
            .MaximumLength(PostConfigurations.IdMaxLength)
            .WithMessage(r => PostErrorMessages.GetIdTooLong(r.Id));

        RuleFor(r => r.CurrentUserId)
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.CurrentUserId))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.CurrentUserId));

        RuleFor(r => r.Title)
            .MinimumLength(PostConfigurations.TitleMinLength)
            .WithMessage(r => PostErrorMessages.GetTitleTooShort(r.Title))
            .MaximumLength(PostConfigurations.TitleMaxLength)
            .WithMessage(r => PostErrorMessages.GetTitleTooLong(r.Title));

        RuleFor(c => c.Content)
            .MinimumLength(PostConfigurations.ContentMinLength)
            .WithMessage(r => PostErrorMessages.GetContentTooShort(r.Content))
            .MaximumLength(PostConfigurations.ContentMaxLength)
            .WithMessage(r => PostErrorMessages.GetContentTooLong(r.Content));
    }
}
