using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Exceptions;

using MediatR;

namespace InstaConnect.Follows.Application.Tests.Features.Users.Assertions;

public static class UserExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowUserNotFoundExceptionAsync(
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<UpdateUserCommandRequest, UpdateUserCommandResponse>(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNotFoundExceptionAsync(
            DeleteUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserAlreadyExistsExceptionAsync(
            AddUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserAlreadyExistsExceptionAsync<AddUserCommandRequest, AddUserCommandResponse>(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
            AddUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNameAlreadyExistsExceptionAsync<AddUserCommandRequest, AddUserCommandResponse>(
                r => r.Name,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
            UpdateUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNameAlreadyExistsExceptionAsync<UpdateUserCommandRequest, UpdateUserCommandResponse>(
                r => r.Name,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
            AddUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserEmailAlreadyExistsExceptionAsync<AddUserCommandRequest, AddUserCommandResponse>(
                r => r.Email,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
            UpdateUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserEmailAlreadyExistsExceptionAsync<UpdateUserCommandRequest, UpdateUserCommandResponse>(
                r => r.Email,
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserNotFoundExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserNotFoundException, TRequest>(
                UserExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserNotFoundExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserNotFoundException, TRequest, TResponse>(
                UserExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserAlreadyExistsExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserAlreadyExistsException, TRequest>(
                UserExceptionErrorMessages.GetAlreadyExistsMessage(new(idPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserAlreadyExistsExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserAlreadyExistsException, TRequest, TResponse>(
                UserExceptionErrorMessages.GetAlreadyExistsMessage(new(idPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserNameAlreadyExistsExceptionAsync<TRequest>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserNameAlreadyExistsException, TRequest>(
                UserExceptionErrorMessages.GetNameAlreadyExistsMessage(new(namePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserNameAlreadyExistsExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserNameAlreadyExistsException, TRequest, TResponse>(
                UserExceptionErrorMessages.GetNameAlreadyExistsMessage(new(namePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync<TRequest>(
            Func<TRequest, string> emailPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserEmailAlreadyExistsException, TRequest>(
                UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(new(emailPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> emailPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserEmailAlreadyExistsException, TRequest, TResponse>(
                UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(new(emailPropertyExpression(request))),
                request,
                cancellationToken);
        }
    }
}
