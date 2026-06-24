using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenValidationExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
			IStringMessageTransformer messageTransformer,
			AddForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Name,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			IStringMessageTransformer messageTransformer,
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Id,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForValueAsync(
			IStringMessageTransformer messageTransformer,
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Value,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPasswordAsync(
			IStringMessageTransformer messageTransformer,
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Password,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForConfirmPasswordAsync(
			IStringMessageTransformer messageTransformer,
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				p => p.ConfirmPassword,
				messageTransformer,
				request,
				cancellationToken);
		}
	}
}
