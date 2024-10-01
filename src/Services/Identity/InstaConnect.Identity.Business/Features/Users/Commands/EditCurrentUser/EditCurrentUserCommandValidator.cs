using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Business.Features.Users.Commands.EditCurrentUser;
public class EditCurrentUserCommandValidator : AbstractValidator<EditCurrentUserCommand>
{
    public EditCurrentUserCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.UserName)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.USER_NAME_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.USER_NAME_MAX_LENGTH);

        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH);

        RuleFor(c => c.LastName)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.LAST_NAME_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH);
    }
}
