using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMockFactory
{
	public static IEmailConfirmationTokenIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new EmailConfirmationTokenIncludeBuilderFactory(new EmailConfirmationTokenIncludeDescriptorFactory());
	}
}
