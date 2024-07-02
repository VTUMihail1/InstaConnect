using FluentValidation;

namespace InstaConnect.Identity.Business.Commands.Account.ResendAccountEmailConfirmation;
public class ResendAccountEmailConfirmationCommandValidator : AbstractValidator<ResendAccountEmailConfirmationCommand>
{
    public ResendAccountEmailConfirmationCommandValidator()
    {
        RuleFor(afc => afc.Email)
            .NotEmpty();
    }
}
