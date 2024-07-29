using FluentValidation;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccount;
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
