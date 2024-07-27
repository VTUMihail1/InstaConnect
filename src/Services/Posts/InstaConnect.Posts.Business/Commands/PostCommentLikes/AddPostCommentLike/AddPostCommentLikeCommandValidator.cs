using FluentValidation;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;
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
