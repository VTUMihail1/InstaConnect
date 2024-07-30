using FluentValidation;
using InstaConnect.Follows.Business.Features.Follows.Utilities;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.ConfirmAccountEmail;

public class ConfirmAccountEmailCommandValidator : AbstractValidator<ConfirmAccountEmailCommand>
{
    public ConfirmAccountEmailCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.Token)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.TOKEN_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.TOKEN_MAX_LENGTH);
    }
}
