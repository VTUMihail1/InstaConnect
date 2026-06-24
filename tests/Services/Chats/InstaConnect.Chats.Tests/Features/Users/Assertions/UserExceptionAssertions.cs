using InstaConnect.Chats.Domain.Features.Users.Exceptions;
using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Chats.Tests.Features.Users.Assertions;

public static class UserExceptionAssertions
{
	extension(Func<Task> action)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserNotFoundException>(
				UserExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync<TRequest>(
			Func<TRequest, UserId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserNotFoundException>(
				UserExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserAlreadyExistsException>(
				UserExceptionErrorMessages.GetAlreadyExistsMessage(new(idPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, UserId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserAlreadyExistsException>(
				UserExceptionErrorMessages.GetAlreadyExistsMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, string> namePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserNameAlreadyExistsException>(
				UserExceptionErrorMessages.GetNameAlreadyExistsMessage(new(namePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, Name> namePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserNameAlreadyExistsException>(
				UserExceptionErrorMessages.GetNameAlreadyExistsMessage(namePropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, string> emailPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserEmailAlreadyExistsException>(
				UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(new(emailPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, Email> emailPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserEmailAlreadyExistsException>(
				UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(emailPropertyExpression(request)),
				cancellationToken);
		}
	}
}
