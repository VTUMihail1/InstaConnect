using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;

using MediatR;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserInvalidDetailsExceptionAsync(
			IssueRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowUserInvalidDetailsExceptionAsync<IssueRefreshTokenCommandRequest, IssueRefreshTokenCommandResponse>(
				r => r.Name,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailNotConfirmedExceptionAsync(
			IssueRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowUserNameEmailNotConfirmedExceptionAsync<IssueRefreshTokenCommandRequest, IssueRefreshTokenCommandResponse>(
				r => r.Name,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailNotConfirmedExceptionAsync(
			RotateRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowUserEmailNotConfirmedExceptionAsync<RotateRefreshTokenCommandRequest, RotateRefreshTokenCommandResponse>(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			RotateRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowUserNotFoundExceptionAsync<RotateRefreshTokenCommandRequest, RotateRefreshTokenCommandResponse>(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteCurrentRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync(
			RotateRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowRefreshTokenNotFoundExceptionAsync<RotateRefreshTokenCommandRequest, RotateRefreshTokenCommandResponse>(
				r => r.Id,
				r => r.Value,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync(
			DeleteCurrentRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowRefreshTokenNotFoundExceptionAsync(
				r => r.Id,
				r => r.Value,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenExpiredExceptionAsync(
			RotateRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowRefreshTokenExpiredExceptionAsync<RotateRefreshTokenCommandRequest, RotateRefreshTokenCommandResponse>(
				r => r.Id,
				r => r.Value,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshExpiredExceptionAsync(
			DeleteCurrentRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowRefreshTokenExpiredExceptionAsync(
				r => r.Id,
				r => r.Value,
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowRefreshTokenNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valueropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest
		{
			await sender.ShouldThrowAsync<RefreshTokenNotFoundException, TRequest>(
				RefreshTokenExceptionErrorMessages.GetNotFoundMessage(new RefreshTokenId(new UserId(idPropertyExpression(request)), valueropertyExpression(request))),
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowRefreshTokenNotFoundExceptionAsync<TRequest, TResponse>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest<TResponse>
		{
			await sender.ShouldThrowAsync<RefreshTokenNotFoundException, TRequest, TResponse>(
				RefreshTokenExceptionErrorMessages.GetNotFoundMessage(new RefreshTokenId(new UserId(idPropertyExpression(request)), valuePropertyExpression(request))),
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowRefreshTokenExpiredExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest
		{
			await sender.ShouldThrowAsync<RefreshTokenExpiredException, TRequest>(
				RefreshTokenExceptionErrorMessages.GetExpiredMessage(new RefreshTokenId(new UserId(idPropertyExpression(request)), valuePropertyExpression(request))),
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowRefreshTokenExpiredExceptionAsync<TRequest, TResponse>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest<TResponse>
		{
			await sender.ShouldThrowAsync<RefreshTokenExpiredException, TRequest, TResponse>(
				RefreshTokenExceptionErrorMessages.GetExpiredMessage(new RefreshTokenId(new UserId(idPropertyExpression(request)), valuePropertyExpression(request))),
				request,
				cancellationToken);
		}
	}
}
