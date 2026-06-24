using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Identity.Domain.Features.Users.Exceptions;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.Users.Assertions;

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

		public async Task ShouldThrowUserNameNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> namePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserNameNotFoundException>(
				UserExceptionErrorMessages.GetNameNotFoundMessage(new(namePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameNotFoundExceptionAsync<TRequest>(
			Func<TRequest, Name> namePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserNameNotFoundException>(
				UserExceptionErrorMessages.GetNameNotFoundMessage(namePropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyTakenExceptionAsync<TRequest>(
			Func<TRequest, string> emailPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserEmailAlreadyTakenException>(
				UserExceptionErrorMessages.GetEmailAlreadyTakenMessage(new(emailPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyTakenExceptionAsync<TRequest>(
			Func<TRequest, Email> emailPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserEmailAlreadyTakenException>(
				UserExceptionErrorMessages.GetEmailAlreadyTakenMessage(emailPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyTakenExceptionAsync<TRequest>(
			Func<TRequest, string> namePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserNameAlreadyTakenException>(
				UserExceptionErrorMessages.GetNameAlreadyTakenMessage(new(namePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyTakenExceptionAsync<TRequest>(
			Func<TRequest, Name> namePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserNameAlreadyTakenException>(
				UserExceptionErrorMessages.GetNameAlreadyTakenMessage(namePropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserInvalidDetailsExceptionAsync<TRequest>(
			Func<TRequest, string> namePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserInvalidDetailsException>(
				UserExceptionErrorMessages.GetInvalidDetailsMessage(new(namePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserInvalidDetailsExceptionAsync<TRequest>(
			Func<TRequest, Name> namePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserInvalidDetailsException>(
				UserExceptionErrorMessages.GetInvalidDetailsMessage(namePropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyConfirmedExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserEmailAlreadyConfirmedException>(
				UserExceptionErrorMessages.GetEmailAlreadyConfirmedMessage(new(idPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyConfirmedExceptionAsync<TRequest>(
			Func<TRequest, UserId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserEmailAlreadyConfirmedException>(
				UserExceptionErrorMessages.GetEmailAlreadyConfirmedMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync<TRequest>(
			Func<TRequest, string> namePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserNameEmailAlreadyConfirmedException>(
				UserExceptionErrorMessages.GetNameEmailAlreadyConfirmedMessage(new(namePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync<TRequest>(
			Func<TRequest, Name> namePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserNameEmailAlreadyConfirmedException>(
				UserExceptionErrorMessages.GetNameEmailAlreadyConfirmedMessage(namePropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailNotConfirmedExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserEmailNotConfirmedException>(
				UserExceptionErrorMessages.GetEmailNotConfirmedMessage(new(idPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailNotConfirmedExceptionAsync<TRequest>(
			Func<TRequest, UserId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserEmailNotConfirmedException>(
				UserExceptionErrorMessages.GetEmailNotConfirmedMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailNotConfirmedExceptionAsync<TRequest>(
			Func<TRequest, string> namePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserNameEmailNotConfirmedException>(
				UserExceptionErrorMessages.GetNameEmailNotConfirmedMessage(new(namePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailNotConfirmedExceptionAsync<TRequest>(
			Func<TRequest, Name> namePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<UserNameEmailNotConfirmedException>(
				UserExceptionErrorMessages.GetNameEmailNotConfirmedMessage(namePropertyExpression(request)),
				cancellationToken);
		}
	}
}
