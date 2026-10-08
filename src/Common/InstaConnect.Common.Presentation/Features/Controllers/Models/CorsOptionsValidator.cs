using FluentValidation;

using InstaConnect.Common.Domain.Features.Validations.Extensions;

namespace InstaConnect.Common.Presentation.Features.Controllers.Models;

public class CorsOptionsValidator : AbstractValidator<CorsOptions>
{
	public CorsOptionsValidator()
	{
		RuleFor(o => o.AllowedOrigins)
			.NotEmptyWithMessage();
	}
}
