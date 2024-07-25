using FluentValidation;
using InstaConnect.Messages.Business.Utilities;

namespace InstaConnect.Follows.Write.Business.Commands.Follows.DeleteFollow;
public class DeleteFollowCommandValidator : AbstractValidator<DeleteFollowCommand>
{
    public DeleteFollowCommandValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .MinimumLength(FollowBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(FollowBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH)
            .MaximumLength(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH);
    }
}
