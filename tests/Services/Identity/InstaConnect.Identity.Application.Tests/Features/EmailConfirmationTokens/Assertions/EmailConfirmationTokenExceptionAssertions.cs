using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

using MediatR;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowUserNameNotFoundExceptionAsync(
            AddEmailConfirmationTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNameNotFoundExceptionAsync(
                r => r.Name,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNotFoundExceptionAsync(
            VerifyEmailConfirmationTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(
            VerifyEmailConfirmationTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(
            VerifyEmailConfirmationTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(
                r => r.Id,
                r => r.Value,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(
            VerifyEmailConfirmationTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(
                r => r.Id,
                r => r.Value,
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valueropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<EmailConfirmationTokenNotFoundException, TRequest>(
                EmailConfirmationTokenExceptionErrorMessages.GetNotFoundMessage(new EmailConfirmationTokenId(new UserId(idPropertyExpression(request)), valueropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valuePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<EmailConfirmationTokenNotFoundException, TRequest, TResponse>(
                EmailConfirmationTokenExceptionErrorMessages.GetNotFoundMessage(new EmailConfirmationTokenId(new UserId(idPropertyExpression(request)), valuePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowEmailConfirmationTokenExpiredExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valuePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<EmailConfirmationTokenExpiredException, TRequest>(
                EmailConfirmationTokenExceptionErrorMessages.GetExpiredMessage(new EmailConfirmationTokenId(new UserId(idPropertyExpression(request)), valuePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowEmailConfirmationTokenExpiredExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valuePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<EmailConfirmationTokenExpiredException, TRequest, TResponse>(
                EmailConfirmationTokenExceptionErrorMessages.GetExpiredMessage(new EmailConfirmationTokenId(new UserId(idPropertyExpression(request)), valuePropertyExpression(request))),
                request,
                cancellationToken);
        }
    }
}
