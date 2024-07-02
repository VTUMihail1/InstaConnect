using FluentValidation;

namespace InstaConnect.Identity.Business.Commands.Account.SendAccountPasswordReset;
public class SendAccountPasswordResetCommandValidator : AbstractValidator<SendAccountPasswordResetCommand>
{
    public SendAccountPasswordResetCommandValidator()
    {
        RuleFor(afc => afc.Email)
            .NotEmpty();
    }
}
