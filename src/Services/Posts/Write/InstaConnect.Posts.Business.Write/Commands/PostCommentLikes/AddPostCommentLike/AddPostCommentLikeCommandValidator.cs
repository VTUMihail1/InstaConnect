using FluentValidation;

namespace InstaConnect.Posts.Business.Write.Commands.PostCommentLikes.AddPostCommentLike;
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
