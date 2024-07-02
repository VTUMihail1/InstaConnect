using FluentValidation;

namespace InstaConnect.Identity.Business.Commands.Account.RegisterAccount;

public class RegisterAccountCommandValidator : AbstractValidator<RegisterAccountCommand>
{
    public RegisterAccountCommandValidator()
    {
        RuleFor(c => c.UserName)
            .NotEmpty();

        RuleFor(c => c.FirstName)
            .NotEmpty();

        RuleFor(c => c.LastName)
            .NotEmpty();

        RuleFor(c => c.Email)
            .NotEmpty();

        RuleFor(c => c.Password)
            .NotEmpty();

        RuleFor(c => c.ConfirmPassword)
            .NotEmpty()
            .Equal(c => c.Password);
    }
}
