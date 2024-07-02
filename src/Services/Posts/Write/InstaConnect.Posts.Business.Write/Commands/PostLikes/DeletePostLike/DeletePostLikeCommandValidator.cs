using FluentValidation;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;
using InstaConnect.Posts.Business.Commands.PostLikes.DeletePostLike;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;

public class DeletePostLikeCommandValidator : AbstractValidator<DeletePostLikeCommand>
{
    public DeletePostLikeCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.CurrentUserId)
            .NotEmpty();
    }
}
