using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Assertions;

public static class UserValidationExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
		IStringMessageTransformer messageTransformer,
		UpdateUserCommandRequest request,
		CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Id,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Id,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			IStringMessageTransformer messageTransformer,
			DeleteUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Id,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
			IStringMessageTransformer messageTransformer,
			UpdateUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Name,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Name,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForFirstNameAsync(
			IStringMessageTransformer messageTransformer,
			UpdateUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.FirstName,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForFirstNameAsync(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.FirstName,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForLastNameAsync(
			IStringMessageTransformer messageTransformer,
			UpdateUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.LastName,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForLastNameAsync(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.LastName,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForEmailAsync(
			IStringMessageTransformer messageTransformer,
			UpdateUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Email,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForEmailAsync(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Email,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForProfileImageAsync(
			IStringMessageTransformer messageTransformer,
			UpdateUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.ProfileImageUrl,
				messageTransformer!,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForProfileImageAsync(
			IStringMessageTransformer messageTransformer,
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.ProfileImageUrl,
				messageTransformer!,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCreatedAtUtcAsync(
			IDateTimeOffsetMessageTransformer messageTransformer,
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.CreatedAtUtc,
				messageTransformer!,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUpdatedAtUtcAsync(
			IDateTimeOffsetMessageTransformer messageTransformer,
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.UpdatedAtUtc,
				messageTransformer!,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUpdatedAtUtcAsync(
			IDateTimeOffsetMessageTransformer messageTransformer,
			UpdateUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowInvalidValidationExceptionAsync(
				p => p.UpdatedAtUtc,
				messageTransformer!,
				request,
				cancellationToken);
		}
	}
}
