using FluentValidation;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteCurrentAccount;
public class DeleteCurrentAccountCommandValidator : AbstractValidator<DeleteCurrentAccountCommand>
{
    public DeleteCurrentAccountCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty();
    }
}
