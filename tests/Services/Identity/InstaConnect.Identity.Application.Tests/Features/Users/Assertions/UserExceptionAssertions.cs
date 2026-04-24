using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Exceptions;

using MediatR;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Assertions;

public static class UserExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowUserNotFoundExceptionAsync(
            UpdateCurrentUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<UpdateCurrentUserCommandRequest, UpdateCurrentUserCommandResponse>(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNotFoundExceptionAsync(
            GetUserByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<GetUserByIdQueryRequest, GetUserByIdQueryResponse>(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNotFoundExceptionAsync(
            GetUserDetailsByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<GetUserDetailsByIdQueryRequest, GetUserDetailsByIdQueryResponse>(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNotFoundExceptionAsync(
            GetCurrentUserByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<GetCurrentUserByIdQueryRequest, GetCurrentUserByIdQueryResponse>(
                r => r.CurrentId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNotFoundExceptionAsync(
            GetCurrentUserDetailsByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<GetCurrentUserDetailsByIdQueryRequest, GetCurrentUserDetailsByIdQueryResponse>(
                r => r.CurrentId,
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

        public async Task ShouldThrowUserNotFoundExceptionAsync(
            DeleteCurrentUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync(
                r => r.CurrentId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNameAlreadyTakenExceptionAsync(
            AddUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNameAlreadyTakenExceptionAsync<AddUserCommandRequest, AddUserCommandResponse>(
                r => r.Name,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNameAlreadyTakenExceptionAsync(
            UpdateCurrentUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNameAlreadyTakenExceptionAsync<UpdateCurrentUserCommandRequest, UpdateCurrentUserCommandResponse>(
                r => r.Name,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserEmailAlreadyTakenExceptionAsync(
            AddUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserEmailAlreadyTakenExceptionAsync<AddUserCommandRequest, AddUserCommandResponse>(
                r => r.Email,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserEmailAlreadyTakenExceptionAsync(
            UpdateCurrentUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserEmailAlreadyTakenExceptionAsync<UpdateCurrentUserCommandRequest, UpdateCurrentUserCommandResponse>(
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

        internal async Task ShouldThrowUserNameNotFoundExceptionAsync<TRequest>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserNameNotFoundException, TRequest>(
                UserExceptionErrorMessages.GetNameNotFoundMessage(new(namePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserNameNotFoundExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserNameNotFoundException, TRequest, TResponse>(
                UserExceptionErrorMessages.GetNameNotFoundMessage(new(namePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserEmailAlreadyTakenExceptionAsync<TRequest>(
            Func<TRequest, string> emailPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserEmailAlreadyTakenException, TRequest>(
                UserExceptionErrorMessages.GetEmailAlreadyTakenMessage(new(emailPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserEmailAlreadyTakenExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> emailPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserEmailAlreadyTakenException, TRequest, TResponse>(
                UserExceptionErrorMessages.GetEmailAlreadyTakenMessage(new(emailPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserNameAlreadyTakenExceptionAsync<TRequest>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserNameAlreadyTakenException, TRequest>(
                UserExceptionErrorMessages.GetNameAlreadyTakenMessage(new(namePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserNameAlreadyTakenExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserNameAlreadyTakenException, TRequest, TResponse>(
                UserExceptionErrorMessages.GetNameAlreadyTakenMessage(new(namePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserInvalidDetailsExceptionAsync<TRequest>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserInvalidDetailsException, TRequest>(
                UserExceptionErrorMessages.GetInvalidDetailsMessage(new(namePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserInvalidDetailsExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserInvalidDetailsException, TRequest, TResponse>(
                UserExceptionErrorMessages.GetInvalidDetailsMessage(new(idPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserEmailAlreadyConfirmedExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserEmailAlreadyConfirmedException, TRequest>(
                UserExceptionErrorMessages.GetEmailAlreadyConfirmedMessage(new(idPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserEmailAlreadyConfirmedExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserEmailAlreadyConfirmedException, TRequest, TResponse>(
                UserExceptionErrorMessages.GetEmailAlreadyConfirmedMessage(new(idPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync<TRequest>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserNameEmailAlreadyConfirmedException, TRequest>(
                UserExceptionErrorMessages.GetNameEmailAlreadyConfirmedMessage(new(namePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserNameEmailAlreadyConfirmedException, TRequest, TResponse>(
                UserExceptionErrorMessages.GetNameEmailAlreadyConfirmedMessage(new(namePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserEmailNotConfirmedExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserEmailNotConfirmedException, TRequest>(
                UserExceptionErrorMessages.GetEmailNotConfirmedMessage(new(idPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserEmailNotConfirmedExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserEmailNotConfirmedException, TRequest, TResponse>(
                UserExceptionErrorMessages.GetEmailNotConfirmedMessage(new(idPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserNameEmailNotConfirmedExceptionAsync<TRequest>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<UserNameEmailNotConfirmedException, TRequest>(
                UserExceptionErrorMessages.GetNameEmailNotConfirmedMessage(new(namePropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowUserNameEmailNotConfirmedExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<UserNameEmailNotConfirmedException, TRequest, TResponse>(
                UserExceptionErrorMessages.GetNameEmailNotConfirmedMessage(new(namePropertyExpression(request))),
                request,
                cancellationToken);
        }
    }
}
