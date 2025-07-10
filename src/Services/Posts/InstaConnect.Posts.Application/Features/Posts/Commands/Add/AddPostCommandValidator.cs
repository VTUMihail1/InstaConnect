using InstaConnect.Common.Extensions;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;
public class AddPostCommandValidator : AbstractValidator<AddPostCommand>
{
    public AddPostCommandValidator()
    {
        RuleFor(r => r.CurrentUserId)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.CurrentUserId.GetLength()))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.CurrentUserId.GetLength()));

        RuleFor(r => r.Title)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetTitleEmpty())
            .MinimumLength(PostConfigurations.TitleMinLength)
            .WithMessage(r => PostErrorMessages.GetTitleTooShort(r.Title.GetLength()))
            .MaximumLength(PostConfigurations.TitleMaxLength)
            .WithMessage(r => PostErrorMessages.GetTitleTooLong(r.Title.GetLength()));

        RuleFor(c => c.Content)
            .NotEmpty()
            .WithMessage(PostErrorMessages.GetContentEmpty())
            .MinimumLength(PostConfigurations.ContentMinLength)
            .WithMessage(r => PostErrorMessages.GetContentTooShort(r.Content.GetLength()))
            .MaximumLength(PostConfigurations.ContentMaxLength)
            .WithMessage(r => PostErrorMessages.GetContentTooLong(r.Content.GetLength()));
    }
}
