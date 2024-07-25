using FluentValidation;
using InstaConnect.Messages.Business.Utilities;

namespace InstaConnect.Follows.Write.Business.Commands.Follows.AddFollow;
public class AddFollowCommandValidator : AbstractValidator<AddFollowCommand>
{
    public AddFollowCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);

        RuleFor(c => c.FollowingId)
            .NotEmpty()
            .MinimumLength(FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH)
            .MaximumLength(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH);
    }
}
