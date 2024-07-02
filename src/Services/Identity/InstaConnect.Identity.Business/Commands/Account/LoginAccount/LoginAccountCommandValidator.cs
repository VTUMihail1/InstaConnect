using FluentValidation;

namespace InstaConnect.Identity.Business.Commands.Account.LoginAccount;
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
