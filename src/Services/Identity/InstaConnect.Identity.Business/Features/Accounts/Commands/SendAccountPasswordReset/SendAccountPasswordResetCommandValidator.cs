using FluentValidation;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.SendAccountPasswordReset;
public class SendAccountPasswordResetCommandValidator : AbstractValidator<SendAccountPasswordResetCommand>
{
    public SendAccountPasswordResetCommandValidator()
    {
        RuleFor(afc => afc.Email)
            .NotEmpty();
    }
}
