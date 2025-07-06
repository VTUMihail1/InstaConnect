namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;
public class AddPostCommandValidator : AbstractValidator<AddPostCommand>
{
    public AddPostCommandValidator()
    {
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
