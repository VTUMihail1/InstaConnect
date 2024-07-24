using FluentValidation;

namespace InstaConnect.Follows.Write.Business.Commands.Follows.DeleteFollow;
public class DeleteFollowCommandValidator : AbstractValidator<DeleteFollowCommand>
{
    public DeleteFollowCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.CurrentUserId)
            .NotEmpty();
    }
}
