using FluentValidation;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;
public class AddPostCommentLikeCommandValidator : AbstractValidator<AddPostCommentLikeCommand>
{
    public AddPostCommentLikeCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty();

        RuleFor(c => c.PostCommentId)
            .NotEmpty();
    }
}
