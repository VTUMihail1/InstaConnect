using FluentValidation;
using InstaConnect.Posts.Business.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Business.Features.PostComments.Commands.AddPostComment;
public class AddPostCommentCommandValidator : AbstractValidator<AddPostCommentCommand>
{
    public AddPostCommentCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);

        RuleFor(c => c.PostId)
            .NotEmpty()
            .MinimumLength(PostCommentBusinessConfigurations.POST_ID_MIN_LENGTH)
            .MaximumLength(PostCommentBusinessConfigurations.POST_ID_MAX_LENGTH);

        RuleFor(c => c.Content)
            .NotEmpty()
            .MinimumLength(PostCommentBusinessConfigurations.CONTENT_MIN_LENGTH)
            .MaximumLength(PostCommentBusinessConfigurations.CONTENT_MAX_LENGTH);
    }
}
