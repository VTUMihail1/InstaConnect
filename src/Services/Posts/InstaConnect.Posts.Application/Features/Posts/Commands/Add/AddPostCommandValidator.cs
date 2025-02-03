using FluentValidation;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.AddPost;
public class AddPostCommandValidator : AbstractValidator<AddPostCommand>
{
    public AddPostCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(c => c.Title)
            .NotEmpty()
            .MinimumLength(PostConfigurations.TitleMinLength)
            .MaximumLength(PostConfigurations.TitleMaxLength);

        RuleFor(c => c.Content)
            .NotEmpty()
            .MinimumLength(PostConfigurations.ContentMinLength)
            .MaximumLength(PostConfigurations.ContentMaxLength);
    }
}
