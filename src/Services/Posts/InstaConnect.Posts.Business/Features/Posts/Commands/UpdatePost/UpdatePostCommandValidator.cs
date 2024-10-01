using FluentValidation;
using InstaConnect.Posts.Common.Features.Posts.Utilities;

namespace InstaConnect.Posts.Business.Features.Posts.Commands.UpdatePost;
public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(PostBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(PostBusinessConfigurations.ID_MAX_LENGTH);

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
