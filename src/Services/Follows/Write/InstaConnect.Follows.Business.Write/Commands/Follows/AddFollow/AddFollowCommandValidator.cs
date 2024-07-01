using FluentValidation;
using InstaConnect.Follows.Business.Commands.Follows.AddFollow;

namespace InstaConnect.Follows.Business.Write.Commands.Follows.AddFollow;
public class AddFollowCommandValidator : AbstractValidator<AddFollowCommand>
{
    public AddFollowCommandValidator()
    {
        RuleFor(afc => afc.CurrentUserId)
            .NotEmpty();

        RuleFor(afc => afc.FollowingId)
            .NotEmpty();
    }
}
