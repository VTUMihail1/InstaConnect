using FluentValidation;

namespace InstaConnect.Posts.Business.Features.Posts.Commands.DeletePost;
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
