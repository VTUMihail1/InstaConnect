using FluentValidation;
using InstaConnect.Posts.Business.Commands.PostComments.AddPostComment;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;
public class AddPostCommentCommandValidator : AbstractValidator<AddPostCommentCommand>
{
    public AddPostCommentCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty();

        RuleFor(c => c.PostId)
            .NotEmpty();

        RuleFor(c => c.Content)
            .NotEmpty();
    }
}
