using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;

using MediatR;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowUserNameNotFoundExceptionAsync(
            AddForgotPasswordTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNameNotFoundExceptionAsync(
                r => r.Name,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNotFoundExceptionAsync(
            VerifyForgotPasswordTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(
            VerifyForgotPasswordTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(
                r => r.Id,
                r => r.Value,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowForgotPasswordTokenExpiredExceptionAsync(
            VerifyForgotPasswordTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowForgotPasswordTokenExpiredExceptionAsync(
                r => r.Id,
                r => r.Value,
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowForgotPasswordTokenNotFoundExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valueropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<ForgotPasswordTokenNotFoundException, TRequest>(
                ForgotPasswordTokenExceptionErrorMessages.GetNotFoundMessage(new ForgotPasswordTokenId(new UserId(idPropertyExpression(request)), valueropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowForgotPasswordTokenNotFoundExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valuePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<ForgotPasswordTokenNotFoundException, TRequest, TResponse>(
                ForgotPasswordTokenExceptionErrorMessages.GetNotFoundMessage(new ForgotPasswordTokenId(new UserId(idPropertyExpression(request)), valuePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowForgotPasswordTokenExpiredExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valuePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<ForgotPasswordTokenExpiredException, TRequest>(
                ForgotPasswordTokenExceptionErrorMessages.GetExpiredMessage(new ForgotPasswordTokenId(new UserId(idPropertyExpression(request)), valuePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowForgotPasswordTokenExpiredExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valuePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<ForgotPasswordTokenExpiredException, TRequest, TResponse>(
                ForgotPasswordTokenExceptionErrorMessages.GetExpiredMessage(new ForgotPasswordTokenId(new UserId(idPropertyExpression(request)), valuePropertyExpression(request))),
                request,
                cancellationToken);
        }
    }
}
