using FluentValidation;
using InstaConnect.Identity.Business.Features.Users.Utilities;

namespace InstaConnect.Identity.Business.Features.Users.Commands.LoginUser;
public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.EMAIL_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.EMAIL_MAX_LENGTH);

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.PASSWORD_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.PASSWORD_MAX_LENGTH);
    }
}
