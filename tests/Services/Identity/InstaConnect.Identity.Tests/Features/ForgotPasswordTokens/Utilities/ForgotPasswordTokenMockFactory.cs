using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMockFactory
{
	public static IForgotPasswordTokenIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new ForgotPasswordTokenIncludeBuilderFactory(new ForgotPasswordTokenIncludeDescriptorFactory());
	}
}
