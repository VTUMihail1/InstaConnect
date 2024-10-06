using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Business.Features.Users.Commands.DeleteCurrentUser;
public class DeleteCurrentUserCommandValidator : AbstractValidator<DeleteCurrentUserCommand>
{
    public DeleteCurrentUserCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.ID_MAX_LENGTH);
    }
}
