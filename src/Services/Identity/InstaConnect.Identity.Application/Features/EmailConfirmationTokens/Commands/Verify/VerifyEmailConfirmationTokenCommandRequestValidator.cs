using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;

namespace InstaConnect.EmailConfirmationTokens.Application.Features.EmailConfirmationTokens.Commands.Add;
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
