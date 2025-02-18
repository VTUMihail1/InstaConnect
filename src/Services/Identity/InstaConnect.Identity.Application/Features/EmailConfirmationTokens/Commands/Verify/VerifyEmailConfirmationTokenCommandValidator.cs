namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;

public class VerifyEmailConfirmationTokenCommandValidator : AbstractValidator<VerifyEmailConfirmationTokenCommand>
{
    public VerifyEmailConfirmationTokenCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty()
            .MinimumLength(UserConfigurations.IdMinLength)
            .MaximumLength(UserConfigurations.IdMaxLength);

        RuleFor(c => c.Token)
            .NotEmpty()
            .MinimumLength(EmailConfirmationTokenConfigurations.ValueMinLength)
            .MaximumLength(EmailConfirmationTokenConfigurations.ValueMaxLength);
    }
}
