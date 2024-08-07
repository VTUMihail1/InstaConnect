using FluentValidation;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccount;
public class EditCurrentAccountCommandValidator : AbstractValidator<EditCurrentAccountCommand>
{
    public EditCurrentAccountCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.UserName)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.USER_NAME_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.USER_NAME_MAX_LENGTH);

        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.FIRST_NAME_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.FIRST_NAME_MAX_LENGTH);

        RuleFor(c => c.LastName)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.LAST_NAME_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.LAST_NAME_MAX_LENGTH);
    }
}
