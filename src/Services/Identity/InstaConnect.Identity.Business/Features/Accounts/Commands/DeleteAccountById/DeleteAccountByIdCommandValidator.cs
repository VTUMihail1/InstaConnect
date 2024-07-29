using FluentValidation;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteAccountById;

public class DeleteAccountByIdCommandValidator : AbstractValidator<DeleteAccountByIdCommand>
{
    public DeleteAccountByIdCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();
    }
}
