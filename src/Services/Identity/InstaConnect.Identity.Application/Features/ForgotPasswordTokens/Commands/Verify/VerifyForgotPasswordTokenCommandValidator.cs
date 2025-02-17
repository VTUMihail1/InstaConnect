namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;
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
