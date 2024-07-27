using FluentValidation;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;
public class DeletePostCommentLikeCommandValidator : AbstractValidator<DeletePostCommentLikeCommand>
{
    public DeletePostCommentLikeCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.CurrentUserId)
            .NotEmpty();
    }
}
