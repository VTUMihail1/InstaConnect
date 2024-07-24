using FluentValidation;

namespace InstaConnect.Posts.Write.Business.Commands.PostCommentLikes.AddPostCommentLike;
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
