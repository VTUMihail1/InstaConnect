using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Common.Infrastructure.Tests.Features.Builders;

public class EmailBuilderFactory
{
	public EmailBuilder Create(Email email)
	{
		return new(email);
	}
}
