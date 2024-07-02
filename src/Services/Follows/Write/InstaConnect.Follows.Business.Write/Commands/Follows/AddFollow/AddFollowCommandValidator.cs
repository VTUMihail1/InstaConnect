using FluentValidation;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;
public class AddFollowCommandValidator : AbstractValidator<AddFollowCommand>
{
    public AddFollowCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty();

        RuleFor(c => c.FollowingId)
            .NotEmpty();
    }
}
