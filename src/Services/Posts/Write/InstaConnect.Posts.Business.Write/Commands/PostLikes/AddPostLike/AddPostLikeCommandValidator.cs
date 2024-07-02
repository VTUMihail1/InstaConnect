using FluentValidation;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;
using InstaConnect.Posts.Business.Commands.PostLikes.AddPostLike;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;
public class AddPostLikeCommandValidator : AbstractValidator<AddPostLikeCommand>
{
    public AddPostLikeCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty();

        RuleFor(c => c.PostId)
            .NotEmpty();
    }
}
