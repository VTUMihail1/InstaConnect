using FluentValidation;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.ResetAccountPassword;
public class ResetAccountPasswordCommandValidator : AbstractValidator<ResetAccountPasswordCommand>
{
    public ResetAccountPasswordCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty();

        RuleFor(c => c.Token)
            .NotEmpty();

        RuleFor(c => c.Password)
            .NotEmpty();

        RuleFor(c => c.ConfirmPassword)
            .NotEmpty()
            .Equal(c => c.Password);
    }
}
