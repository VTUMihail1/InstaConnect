using FluentValidation;
using InstaConnect.Identity.Common.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Commands.ConfirmUserEmail;

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
