using FluentValidation;
using InstaConnect.Identity.Business.Commands.Account.ResendAccountEmailConfirmation;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;
public class ResendAccountEmailConfirmationCommandValidator : AbstractValidator<ResendAccountEmailConfirmationCommand>
{
    public ResendAccountEmailConfirmationCommandValidator()
    {
        RuleFor(afc => afc.Email)
            .NotEmpty();
    }
}
