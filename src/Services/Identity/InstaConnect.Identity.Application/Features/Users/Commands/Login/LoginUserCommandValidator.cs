using FluentValidation;

using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Login;
public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .MinimumLength(UserConfigurations.EmailMinLength)
            .MaximumLength(UserConfigurations.EmailMaxLength);

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(UserConfigurations.PasswordMinLength)
            .MaximumLength(UserConfigurations.PasswordMaxLength);
    }
}
