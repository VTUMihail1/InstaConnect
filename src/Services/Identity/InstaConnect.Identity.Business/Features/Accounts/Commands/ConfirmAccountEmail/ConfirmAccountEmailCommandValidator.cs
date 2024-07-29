using FluentValidation;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.ConfirmAccountEmail;

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
