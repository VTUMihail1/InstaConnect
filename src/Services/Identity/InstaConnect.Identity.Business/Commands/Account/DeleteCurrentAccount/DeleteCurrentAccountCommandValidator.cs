using FluentValidation;

namespace InstaConnect.Identity.Business.Commands.Account.DeleteCurrentAccount;
public class DeleteCurrentAccountCommandValidator : AbstractValidator<DeleteCurrentAccountCommand>
{
    public DeleteCurrentAccountCommandValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty();
    }
}
