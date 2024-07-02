using FluentValidation;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;
using InstaConnect.Posts.Business.Commands.PostComments.UpdatePostComment;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;
public class UpdatePostCommentCommandValidator : AbstractValidator<UpdatePostCommentCommand>
{
    public UpdatePostCommentCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.CurrentUserId)
            .NotEmpty();

        RuleFor(c => c.Content)
            .NotEmpty();
    }
}
