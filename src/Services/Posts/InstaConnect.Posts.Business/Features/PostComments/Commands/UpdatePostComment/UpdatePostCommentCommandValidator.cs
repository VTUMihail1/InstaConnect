using FluentValidation;
using InstaConnect.Posts.Business.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Business.Features.PostComments.Commands.UpdatePostComment;
public class UpdatePostCommentCommandValidator : AbstractValidator<UpdatePostCommentCommand>
{
    public UpdatePostCommentCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(PostCommentBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(PostCommentBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);

        RuleFor(c => c.Content)
            .NotEmpty()
            .MinimumLength(PostCommentBusinessConfigurations.CONTENT_MIN_LENGTH)
            .MaximumLength(PostCommentBusinessConfigurations.CONTENT_MAX_LENGTH);
    }
}
