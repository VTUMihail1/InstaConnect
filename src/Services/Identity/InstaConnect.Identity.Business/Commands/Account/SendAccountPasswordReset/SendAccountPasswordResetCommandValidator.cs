using FluentValidation;
using InstaConnect.Identity.Business.Commands.Account.SendAccountPasswordReset;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;
public class SendAccountPasswordResetCommandValidator : AbstractValidator<SendAccountPasswordResetCommand>
{
    public SendAccountPasswordResetCommandValidator()
    {
        RuleFor(afc => afc.Email)
            .NotEmpty();
    }
}
