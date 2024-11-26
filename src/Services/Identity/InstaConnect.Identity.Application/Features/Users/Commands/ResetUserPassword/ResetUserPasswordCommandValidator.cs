using FluentValidation;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Commands.ResetUserPassword;
public class ResetUserPasswordCommandValidator : AbstractValidator<ResetUserPasswordCommand>
{
    public ResetUserPasswordCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.ID_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.ID_MAX_LENGTH);

        RuleFor(c => c.Token)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.TOKEN_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.TOKEN_MAX_LENGTH);

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(UserBusinessConfigurations.PASSWORD_MIN_LENGTH)
            .MaximumLength(UserBusinessConfigurations.PASSWORD_MAX_LENGTH);

        RuleFor(c => c.ConfirmPassword)
            .NotEmpty()
            .Equal(c => c.Password);
    }
}
