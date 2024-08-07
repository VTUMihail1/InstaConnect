using FluentValidation;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.ResetAccountPassword;
public class ResetAccountPasswordCommandValidator : AbstractValidator<ResetAccountPasswordCommand>
{
    public ResetAccountPasswordCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.Token)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.TOKEN_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.TOKEN_MAX_LENGTH);

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.PASSWORD_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.PASSWORD_MAX_LENGTH);

        RuleFor(c => c.ConfirmPassword)
            .NotEmpty()
            .Equal(c => c.Password);
    }
}
