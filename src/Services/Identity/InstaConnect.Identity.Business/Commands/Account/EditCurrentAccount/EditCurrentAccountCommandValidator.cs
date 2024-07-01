using FluentValidation;
using InstaConnect.Identity.Business.Commands.Account.EditAccount;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;
public class EditCurrentAccountCommandValidator : AbstractValidator<EditCurrentAccountCommand>
{
    public EditCurrentAccountCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty();

        RuleFor(c => c.UserName)
            .NotEmpty();

        RuleFor(c => c.FirstName)
            .NotEmpty();

        RuleFor(c => c.LastName)
            .NotEmpty();
    }
}
