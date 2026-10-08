using FluentValidation;

using InstaConnect.Common.Domain.Features.Validations.Extensions;

namespace InstaConnect.Common.Presentation.Features.Common.Models;

public class MainOptionsValidator : AbstractValidator<MainOptions>
{
	public MainOptionsValidator()
	{
		RuleFor(o => o.BaseUrl)
			.NotEmptyWithMessage();
	}
}
