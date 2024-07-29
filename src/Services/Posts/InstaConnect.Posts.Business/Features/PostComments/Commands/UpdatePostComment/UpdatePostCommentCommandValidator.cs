using FluentValidation;

namespace InstaConnect.Posts.Business.Features.PostComments.Commands.UpdatePostComment;
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
