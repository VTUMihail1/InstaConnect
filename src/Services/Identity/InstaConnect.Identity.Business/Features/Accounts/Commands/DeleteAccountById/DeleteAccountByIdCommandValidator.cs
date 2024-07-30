using FluentValidation;
using InstaConnect.Follows.Business.Features.Follows.Utilities;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteAccountById;

public class DeleteAccountByIdCommandValidator : AbstractValidator<DeleteAccountByIdCommand>
{
    public DeleteAccountByIdCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .MinimumLength(AccountBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(AccountBusinessConfigurations.ID_MAX_LENGTH);
    }
}
