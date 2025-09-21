using InstaConnect.Identity.Domain.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Utilities;
using InstaConnect.Posts.Common.Features.RefreshTokens.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.RefreshTokens.Utilities;

namespace InstaConnect.RefreshTokens.Application.Features.RefreshTokens.Commands.Add;
public class RotateRefreshTokenCommandRequestValidator : AbstractValidator<RotateRefreshTokenCommandRequest>
{
    public RotateRefreshTokenCommandRequestValidator()
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
            .WithMessage(RefreshTokenErrorMessages.GetValueEmpty())
            .MinimumLength(RefreshTokenConfigurations.ValueMinLength)
            .WithMessage(r => RefreshTokenErrorMessages.GetValueTooShort(r.Value.Length))
            .MaximumLength(RefreshTokenConfigurations.ValueMaxLength)
            .WithMessage(r => RefreshTokenErrorMessages.GetValueTooLong(r.Value.Length));
    }
}
