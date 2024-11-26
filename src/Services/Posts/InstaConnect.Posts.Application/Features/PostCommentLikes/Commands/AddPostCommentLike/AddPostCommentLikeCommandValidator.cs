using FluentValidation;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.AddPostCommentLike;
public class AddPostCommentLikeCommandValidator : AbstractValidator<AddPostCommentLikeCommand>
{
    public AddPostCommentLikeCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);

        RuleFor(c => c.PostCommentId)
            .NotEmpty()
            .MinimumLength(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MIN_LENGTH)
            .MaximumLength(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MAX_LENGTH);
    }
}
