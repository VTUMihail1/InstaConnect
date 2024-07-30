using FluentValidation;
using InstaConnect.Follows.Business.Features.Follows.Utilities;

namespace InstaConnect.Posts.Business.Features.PostLikes.Commands.AddPostLike;
public class AddPostLikeCommandValidator : AbstractValidator<AddPostLikeCommand>
{
    public AddPostLikeCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);

        RuleFor(c => c.PostId)
            .NotEmpty()
            .MinimumLength(PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH)
            .MaximumLength(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH);
    }
}
