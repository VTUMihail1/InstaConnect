using FluentValidation;
using InstaConnect.Follows.Business.Features.Follows.Utilities;

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
