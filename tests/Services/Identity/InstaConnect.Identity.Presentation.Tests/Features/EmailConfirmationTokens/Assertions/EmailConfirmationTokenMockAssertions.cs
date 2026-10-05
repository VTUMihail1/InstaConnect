using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMockAssertions
{

	extension(IApplicationSender sender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
			AddEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsAddEmailConfirmationTokenCommandRequest(), cancellationToken);
		}
		public async Task ShouldHaveReceivedOneSendAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsVerifyEmailConfirmationTokenCommandRequest(), cancellationToken);
		}
	}
}
