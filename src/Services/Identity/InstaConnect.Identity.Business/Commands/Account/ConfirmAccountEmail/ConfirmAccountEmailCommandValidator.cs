using FluentValidation;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class ConfirmAccountEmailCommandValidator : AbstractValidator<ConfirmAccountEmailCommand>
{
    public ConfirmAccountEmailCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty();

        RuleFor(c => c.Token)
            .NotEmpty();
    }
}
