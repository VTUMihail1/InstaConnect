using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;

public class ForgotPasswordTokenIdBuilderFactory
{
	public ForgotPasswordTokenIdBuilder Create(ForgotPasswordTokenId id)
	{
		return new(id);
	}
}
