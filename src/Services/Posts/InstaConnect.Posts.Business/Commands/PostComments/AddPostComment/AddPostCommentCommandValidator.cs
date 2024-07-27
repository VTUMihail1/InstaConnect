using FluentValidation;

namespace InstaConnect.Posts.Business.Commands.PostComments.AddPostComment;
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
