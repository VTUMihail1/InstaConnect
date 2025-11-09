namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;
public class IssueRefreshTokenCommandRequestValidator : AbstractValidator<IssueRefreshTokenCommandRequest>
{
    public IssueRefreshTokenCommandRequestValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetNameEmpty())
            .MinimumLength(UserConfigurations.NameMinLength)
            .WithMessage(r => UserErrorMessages.GetNameTooShort(r.Name.Length))
            .MaximumLength(UserConfigurations.NameMaxLength)
            .WithMessage(r => UserErrorMessages.GetNameTooLong(r.Name.Length));

        RuleFor(r => r.Password)
            .NotEmpty()
            .WithMessage(UserErrorMessages.GetPasswordEmpty())
            .MinimumLength(UserConfigurations.PasswordMinLength)
            .WithMessage(r => UserErrorMessages.GetPasswordTooShort(r.Password.Length))
            .MaximumLength(UserConfigurations.PasswordMaxLength)
            .WithMessage(r => UserErrorMessages.GetPasswordTooLong(r.Password.Length));
    }
}
