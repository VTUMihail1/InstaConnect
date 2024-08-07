using FluentValidation;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.SendAccountPasswordReset;
public class SendAccountPasswordResetCommandValidator : AbstractValidator<SendAccountPasswordResetCommand>
{
    public SendAccountPasswordResetCommandValidator()
    {
        RuleFor(afc => afc.Email)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.EMAIL_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.EMAIL_MAX_LENGTH);
        ;
    }
}
