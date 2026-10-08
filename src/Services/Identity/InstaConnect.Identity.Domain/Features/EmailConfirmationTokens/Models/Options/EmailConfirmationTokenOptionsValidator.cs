using FluentValidation;

using InstaConnect.Common.Domain.Features.Validations.Extensions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;

public class EmailConfirmationTokenOptionsValidator : AbstractValidator<EmailConfirmationTokenOptions>
{
	public EmailConfirmationTokenOptionsValidator()
	{
		RuleFor(o => o.LifetimeSeconds)
			.NotEmptyWithMessage();
	}
}
