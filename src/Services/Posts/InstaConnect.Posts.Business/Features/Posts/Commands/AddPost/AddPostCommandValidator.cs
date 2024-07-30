using FluentValidation;
using InstaConnect.Follows.Business.Features.Follows.Utilities;

namespace InstaConnect.Posts.Business.Features.Posts.Commands.AddPost;
public class AddPostCommandValidator : AbstractValidator<AddPostCommand>
{
    public AddPostCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);

        RuleFor(c => c.Title)
            .NotEmpty()
            .MinimumLength(PostBusinessConfigurations.TITLE_MIN_LENGTH)
            .MaximumLength(PostBusinessConfigurations.TITLE_MAX_LENGTH);

        RuleFor(c => c.Content)
            .NotEmpty()
            .MinimumLength(PostBusinessConfigurations.CONTENT_MIN_LENGTH)
            .MaximumLength(PostBusinessConfigurations.CONTENT_MAX_LENGTH);
    }
}
