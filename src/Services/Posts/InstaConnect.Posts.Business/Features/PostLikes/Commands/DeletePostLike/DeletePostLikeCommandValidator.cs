using FluentValidation;
using InstaConnect.Follows.Business.Features.Follows.Utilities;

namespace InstaConnect.Posts.Business.Features.PostLikes.Commands.DeletePostLike;

public class DeletePostLikeCommandValidator : AbstractValidator<DeletePostLikeCommand>
{
    public DeletePostLikeCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(PostLikeBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(PostLikeBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);
    }
}
