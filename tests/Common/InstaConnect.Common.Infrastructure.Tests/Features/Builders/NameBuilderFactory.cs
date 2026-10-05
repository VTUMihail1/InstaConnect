using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Common.Infrastructure.Tests.Features.Builders;

public class NameBuilderFactory
{
	public NameBuilder Create(Name name)
	{
		return new(name);
	}
}
