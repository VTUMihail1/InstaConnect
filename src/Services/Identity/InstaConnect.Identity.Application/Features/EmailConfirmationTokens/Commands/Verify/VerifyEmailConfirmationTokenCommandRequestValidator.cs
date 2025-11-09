namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;
public class VerifyEmailConfirmationTokenCommandRequestValidator : AbstractValidator<VerifyEmailConfirmationTokenCommandRequest>
{
    public VerifyEmailConfirmationTokenCommandRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetIdEmpty())
            .MinimumLength(UserConfigurations.IdMinLength)
            .WithMessage(r => UserErrorMessages.GetIdTooShort(r.Id.Length))
            .MaximumLength(UserConfigurations.IdMaxLength)
            .WithMessage(r => UserErrorMessages.GetIdTooLong(r.Id.Length));

        RuleFor(r => r.Value)
            .NotEmpty()
            .WithMessage(EmailConfirmationTokenErrorMessages.GetValueEmpty())
            .MinimumLength(EmailConfirmationTokenConfigurations.ValueMinLength)
            .WithMessage(r => EmailConfirmationTokenErrorMessages.GetValueTooShort(r.Value.Length))
            .MaximumLength(EmailConfirmationTokenConfigurations.ValueMaxLength)
            .WithMessage(r => EmailConfirmationTokenErrorMessages.GetValueTooLong(r.Value.Length));
    }
}
