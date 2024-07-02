using FluentValidation;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;
using InstaConnect.Posts.Business.Commands.Posts.DeletePost;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;
public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
{
    public DeletePostCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.CurrentUserId)
            .NotEmpty();
    }
}
