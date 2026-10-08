using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;

public class EmailConfirmationTokenIdBuilderFactory
{
	public EmailConfirmationTokenIdBuilder Create(EmailConfirmationTokenId id)
	{
		return new(id);
	}
}
