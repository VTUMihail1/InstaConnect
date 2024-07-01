using FluentValidation;
using InstaConnect.Identity.Business.Commands.Account.EditAccount;
using InstaConnect.Identity.Business.Commands.Account.LoginAccount;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;
public class LoginAccountCommandValidator : AbstractValidator<LoginAccountCommand>
{
    public LoginAccountCommandValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty();

        RuleFor(c => c.Password)
            .NotEmpty();
    }
}
