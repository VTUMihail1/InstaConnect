using FluentValidation;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.ResendAccountEmailConfirmation;
public class ResendAccountEmailConfirmationCommandValidator : AbstractValidator<ResendAccountEmailConfirmationCommand>
{
    public ResendAccountEmailConfirmationCommandValidator()
    {
        RuleFor(afc => afc.Email)
            .NotEmpty();
    }
}
