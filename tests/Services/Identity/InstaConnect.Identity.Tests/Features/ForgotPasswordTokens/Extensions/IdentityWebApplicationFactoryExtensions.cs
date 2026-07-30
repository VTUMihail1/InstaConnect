using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Helpers;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IForgotPasswordTokenEventClient CreateForgotPasswordTokenEventClient()
		{
			var eventHarness = webApplicationFactory.Services.GetEventHarness();

			return new ForgotPasswordTokenEventClient(eventHarness);
		}
	}
}
