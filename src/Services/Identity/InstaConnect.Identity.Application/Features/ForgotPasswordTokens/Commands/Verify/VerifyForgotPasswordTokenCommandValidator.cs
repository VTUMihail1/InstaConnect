using FluentValidation;
using InstaConnect.Identity.Common.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Commands.ResetUserPassword;
public class VerifyForgotPasswordTokenCommandValidator : AbstractValidator<VerifyForgotPasswordTokenCommand>
{
    public VerifyForgotPasswordTokenCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(c => c.Token)
            .NotEmpty()
            .MinimumLength(ForgotPasswordTokenConfigurations.ValueMinLength)
            .MaximumLength(ForgotPasswordTokenConfigurations.ValueMaxLength);

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(UserConfigurations.PasswordMinLength)
            .MaximumLength(UserConfigurations.PasswordMaxLength);

        RuleFor(c => c.ConfirmPassword)
            .NotEmpty()
            .Equal(c => c.Password);
    }
}
