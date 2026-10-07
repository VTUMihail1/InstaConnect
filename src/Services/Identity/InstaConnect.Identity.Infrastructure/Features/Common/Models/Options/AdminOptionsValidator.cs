using FluentValidation;

using InstaConnect.Common.Domain.Features.Validations.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.Common.Models.Options;

public class AdminOptionsValidator : AbstractValidator<AdminOptions>
{
	public AdminOptionsValidator()
	{
		RuleFor(o => o.Name)
			.NotEmptyWithMessage();

		RuleFor(o => o.Email)
			.NotEmptyWithMessage();

		RuleFor(o => o.FirstName)
			.NotEmptyWithMessage();

		RuleFor(o => o.LastName)
			.NotEmptyWithMessage();

		RuleFor(o => o.Password)
			.NotEmptyWithMessage();
	}
}
