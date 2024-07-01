using FluentValidation;
using InstaConnect.Identity.Business.Commands.Account.DeleteAccountById;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class DeleteAccountByIdCommandValidator : AbstractValidator<DeleteAccountByIdCommand>
{
    public DeleteAccountByIdCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();
    }
}
