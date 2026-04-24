using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Events.Features.Tokens.Models;
using InstaConnect.Identity.Domain.Features.UserClaims.Exceptions;

using MediatR;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Assertions;

public static class UserClaimExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowUserNotFoundExceptionAsync(
            GetAllUserClaimsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<GetAllUserClaimsQueryRequest, GetAllUserClaimsQueryResponse>(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNotFoundExceptionAsync(
            AddUserClaimCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<AddUserClaimCommandRequest, AddUserClaimCommandResponse>(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNotFoundExceptionAsync(
            DeleteUserClaimCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserClaimAlreadyExistsExceptionAsync(
            AddUserClaimCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserClaimAlreadyExistsExceptionAsync<AddUserClaimCommandRequest, AddUserClaimCommandResponse>(
                r => r.Id,
                r => r.Claim,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserClaimNotFoundExceptionAsync(
            DeleteUserClaimCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserClaimNotFoundExceptionAsync(
                r => r.Id,
                r => r.Claim,
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserClaimNotFoundExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, ApplicationClaims> claimPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserClaimNotFoundException, TRequest>(
                UserClaimExceptionErrorMessages.GetNotFoundMessage(new UserClaimId(new UserId(idPropertyExpression(request)), claimPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserClaimNotFoundExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, ApplicationClaims> claimPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserClaimNotFoundException, TRequest, TResponse>(
                UserClaimExceptionErrorMessages.GetNotFoundMessage(new UserClaimId(new UserId(idPropertyExpression(request)), claimPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserClaimAlreadyExistsExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, ApplicationClaims> claimPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserClaimAlreadyExistsException, TRequest>(
                UserClaimExceptionErrorMessages.GetAlreadyExistsMessage(new UserClaimId(new UserId(idPropertyExpression(request)), claimPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserClaimAlreadyExistsExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, ApplicationClaims> claimPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserClaimAlreadyExistsException, TRequest, TResponse>(
                UserClaimExceptionErrorMessages.GetAlreadyExistsMessage(new UserClaimId(new UserId(idPropertyExpression(request)), claimPropertyExpression(request))),
                request,
                cancellationToken);
        }
    }
}
