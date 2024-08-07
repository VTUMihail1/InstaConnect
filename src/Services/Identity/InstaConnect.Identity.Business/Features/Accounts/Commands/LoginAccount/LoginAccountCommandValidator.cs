using FluentValidation;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.LoginAccount;
public class LoginAccountCommandValidator : AbstractValidator<LoginAccountCommand>
{
    public LoginAccountCommandValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.EMAIL_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.EMAIL_MAX_LENGTH);

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.PASSWORD_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.PASSWORD_MAX_LENGTH);
    }
}
