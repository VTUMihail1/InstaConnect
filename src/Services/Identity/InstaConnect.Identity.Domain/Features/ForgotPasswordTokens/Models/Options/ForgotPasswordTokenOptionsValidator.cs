using FluentValidation;

using InstaConnect.Common.Domain.Features.Validations.Extensions;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;

public class ForgotPasswordTokenOptionsValidator : AbstractValidator<ForgotPasswordTokenOptions>
{
	public ForgotPasswordTokenOptionsValidator()
	{
		RuleFor(o => o.LifetimeSeconds)
			.NotEmptyWithMessage();
	}
}
