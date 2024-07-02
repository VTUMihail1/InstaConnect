using FluentValidation;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;
using InstaConnect.Posts.Business.Commands.PostComments.DeletePostComment;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;
public class DeletePostCommentCommandValidator : AbstractValidator<DeletePostCommentCommand>
{
    public DeletePostCommentCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.CurrentUserId)
            .NotEmpty();
    }
}
