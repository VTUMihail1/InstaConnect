using FluentValidation;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.ResendAccountEmailConfirmation;
public class ResendAccountEmailConfirmationCommandValidator : AbstractValidator<ResendAccountEmailConfirmationCommand>
{
    public ResendAccountEmailConfirmationCommandValidator()
    {
        RuleFor(afc => afc.Email)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.EMAIL_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.EMAIL_MAX_LENGTH);
    }
}
