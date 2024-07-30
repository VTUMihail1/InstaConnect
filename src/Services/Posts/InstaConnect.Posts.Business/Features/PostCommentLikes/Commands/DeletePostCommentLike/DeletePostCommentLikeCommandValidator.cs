using FluentValidation;
using InstaConnect.Follows.Business.Features.Follows.Utilities;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.DeletePostCommentLike;
public class DeletePostCommentLikeCommandValidator : AbstractValidator<DeletePostCommentLikeCommand>
{
    public DeletePostCommentLikeCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(PostCommentLikeBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(PostCommentLikeBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);
    }
}
