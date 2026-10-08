using FluentValidation;

using InstaConnect.Common.Domain.Features.Validations.Extensions;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;

public class RefreshTokenOptionsValidator : AbstractValidator<RefreshTokenOptions>
{
	public RefreshTokenOptionsValidator()
	{
		RuleFor(o => o.LifetimeSeconds)
			.NotEmptyWithMessage();
	}
}
