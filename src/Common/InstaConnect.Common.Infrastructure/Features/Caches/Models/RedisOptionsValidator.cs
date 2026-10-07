using FluentValidation;

using InstaConnect.Common.Domain.Features.Validations.Extensions;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Models;

public class RedisOptionsValidator : AbstractValidator<RedisOptions>
{
	public RedisOptionsValidator()
	{
		RuleFor(o => o.ConnectionString)
			.NotEmptyWithMessage();
	}
}
