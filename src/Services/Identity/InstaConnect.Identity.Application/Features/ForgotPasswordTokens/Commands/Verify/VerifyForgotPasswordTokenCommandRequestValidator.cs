namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;
public class VerifyForgotPasswordTokenCommandRequestValidator : AbstractValidator<VerifyForgotPasswordTokenCommandRequest>
{
    public VerifyForgotPasswordTokenCommandRequestValidator()
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
            .WithMessage(ForgotPasswordTokenErrorMessages.GetValueEmpty())
            .MinimumLength(ForgotPasswordTokenConfigurations.ValueMinLength)
            .WithMessage(r => ForgotPasswordTokenErrorMessages.GetValueTooShort(r.Value.Length))
            .MaximumLength(ForgotPasswordTokenConfigurations.ValueMaxLength)
            .WithMessage(r => ForgotPasswordTokenErrorMessages.GetValueTooLong(r.Value.Length));

        RuleFor(r => r.Password)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetPasswordEmpty())
            .MinimumLength(UserConfigurations.PasswordMinLength)
            .WithMessage(r => UserErrorMessages.GetPasswordTooShort(r.Password.Length))
            .MaximumLength(UserConfigurations.PasswordMaxLength)
            .WithMessage(r => UserErrorMessages.GetPasswordTooLong(r.Password.Length));

        RuleFor(r => r.ConfirmPassword)
            .Equal(r => r.Password)
            .WithMessage(UserErrorMessages.GetConfirmPasswordNotEqualsPassword());
    }
}
