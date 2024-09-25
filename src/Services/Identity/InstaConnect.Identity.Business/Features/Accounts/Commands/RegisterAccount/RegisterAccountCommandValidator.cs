using FluentValidation;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.RegisterAccount;

public class RegisterAccountCommandValidator : AbstractValidator<RegisterAccountCommand>
{
    public RegisterAccountCommandValidator()
    {
        RuleFor(c => c.UserName)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.USER_NAME_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.USER_NAME_MAX_LENGTH);

        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.FIRST_NAME_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.FIRST_NAME_MAX_LENGTH);

        RuleFor(c => c.LastName)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.LAST_NAME_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.LAST_NAME_MAX_LENGTH);

        RuleFor(c => c.Email)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.EMAIL_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.EMAIL_MAX_LENGTH);

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.PASSWORD_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.PASSWORD_MAX_LENGTH);

        RuleFor(c => c.ConfirmPassword)
            .Equal(c => c.Password);
    }
}
