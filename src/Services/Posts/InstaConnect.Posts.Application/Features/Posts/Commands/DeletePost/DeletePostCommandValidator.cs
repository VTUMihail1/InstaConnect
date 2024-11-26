using FluentValidation;
using InstaConnect.Posts.Common.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.DeletePost;
public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
{
    public DeletePostCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(PostBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(PostBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);
    }
}
