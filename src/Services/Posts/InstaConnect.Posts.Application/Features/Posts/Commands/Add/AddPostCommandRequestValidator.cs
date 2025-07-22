using InstaConnect.Common.Extensions;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;
public class AddPostCommandRequestValidator : AbstractValidator<AddPostCommandRequest>
{
    public AddPostCommandRequestValidator()
    {
        RuleFor(r => r.CurrentUserId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.CurrentUserId.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.CurrentUserId.Length));

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
