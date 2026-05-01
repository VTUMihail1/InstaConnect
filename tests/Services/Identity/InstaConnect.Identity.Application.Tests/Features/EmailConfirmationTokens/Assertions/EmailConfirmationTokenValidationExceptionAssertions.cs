using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenValidationExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
			IStringMessageTransformer messageTransformer,
			AddEmailConfirmationTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Name,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			IStringMessageTransformer messageTransformer,
			VerifyEmailConfirmationTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Id,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForValueAsync(
			IStringMessageTransformer messageTransformer,
			VerifyEmailConfirmationTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Value,
				messageTransformer,
				request,
				cancellationToken);
		}
	}
}
