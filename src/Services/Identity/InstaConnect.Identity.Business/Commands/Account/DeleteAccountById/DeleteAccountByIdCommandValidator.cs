using FluentValidation;

namespace InstaConnect.Identity.Business.Commands.Account.DeleteAccountById;

public class DeleteAccountByIdCommandValidator : AbstractValidator<DeleteAccountByIdCommand>
{
    public DeleteAccountByIdCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();
    }
}
