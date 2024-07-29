using FluentValidation;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.LoginAccount;
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
