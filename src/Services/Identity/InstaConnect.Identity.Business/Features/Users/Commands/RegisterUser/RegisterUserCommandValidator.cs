using FluentValidation;
using InstaConnect.Identity.Business.Features.Users.Utilities;

namespace InstaConnect.Identity.Business.Features.Users.Commands.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
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

        RuleFor(c => c.Email)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.EMAIL_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.EMAIL_MAX_LENGTH);

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.PASSWORD_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.PASSWORD_MAX_LENGTH);

        RuleFor(c => c.ConfirmPassword)
            .Equal(c => c.Password);
    }
}
