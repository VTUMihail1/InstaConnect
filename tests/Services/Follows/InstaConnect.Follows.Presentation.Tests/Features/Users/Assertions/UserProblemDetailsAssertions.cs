using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Follows.Presentation.Tests.Features.Users.Assertions;

public static class UserProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyUserNotFound(
        UpdateUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            DeleteUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserAlreadyExists(
            AddUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserAlreadyExists(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserNameAlreadyExists(
            AddUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserNameAlreadyExists(
                r => r.Name,
                request);
        }

        public void ShouldSatisfyUserNameAlreadyExists(
            UpdateUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserNameAlreadyExists(
                r => r.Name,
                request);
        }

        public void ShouldSatisfyUserEmailAlreadyExists(
            AddUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserEmailAlreadyExists(
                r => r.Email,
                request);
        }

        public void ShouldSatisfyUserEmailAlreadyExists(
            UpdateUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserEmailAlreadyExists(
                r => r.Email,
                request);
        }

        internal void ShouldSatisfyUserNotFound<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyNotFound(
                UserExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))));
        }

        internal void ShouldSatisfyUserAlreadyExists<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                UserExceptionErrorMessages.GetAlreadyExistsMessage(new(idPropertyExpression(request))));
        }

        internal void ShouldSatisfyUserNameAlreadyExists<TRequest>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                UserExceptionErrorMessages.GetNameAlreadyExistsMessage(new(namePropertyExpression(request))));
        }

        internal void ShouldSatisfyUserEmailAlreadyExists<TRequest>(
            Func<TRequest, string> emailPropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(new(emailPropertyExpression(request))));
        }
    }
}
