using FluentValidation;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;
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
