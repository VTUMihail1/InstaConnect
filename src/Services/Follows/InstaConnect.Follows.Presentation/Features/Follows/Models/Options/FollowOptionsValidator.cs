using FluentValidation;

using InstaConnect.Common.Domain.Features.Validations.Extensions;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Options;

public class FollowOptionsValidator : AbstractValidator<FollowOptions>
{
	public FollowOptionsValidator()
	{
		RuleFor(o => o.HubRoute)
			.NotEmptyWithMessage();
	}
}
