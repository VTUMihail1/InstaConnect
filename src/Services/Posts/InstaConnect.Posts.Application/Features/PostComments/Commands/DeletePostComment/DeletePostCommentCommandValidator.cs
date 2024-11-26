using FluentValidation;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.Features.PostComments.Commands.DeletePostComment;
public class DeletePostCommentCommandValidator : AbstractValidator<DeletePostCommentCommand>
{
    public DeletePostCommentCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(PostCommentBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(PostCommentBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);
    }
}
