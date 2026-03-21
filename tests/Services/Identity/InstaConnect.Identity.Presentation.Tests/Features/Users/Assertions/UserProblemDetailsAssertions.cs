using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Assertions;

public static class UserProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyUserNotFound(
            UpdateCurrentUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            GetUserByIdQueryRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            GetUserDetailsByIdQueryRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            GetCurrentUserByIdQueryRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.CurrentId,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            GetCurrentUserDetailsByIdQueryRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.CurrentId,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            DeleteUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            DeleteCurrentUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.CurrentId,
                request);
        }

        public void ShouldSatisfyUserNameAlreadyTaken(
            AddUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserNameAlreadyTaken(
                r => r.Name,
                request);
        }

        public void ShouldSatisfyUserNameAlreadyTaken(
            UpdateCurrentUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserNameAlreadyTaken(
                r => r.Name,
                request);
        }

        public void ShouldSatisfyUserEmailAlreadyTaken(
            AddUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserEmailAlreadyTaken(
                r => r.Email,
                request);
        }

        public void ShouldSatisfyUserEmailAlreadyTaken(
            UpdateCurrentUserCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserEmailAlreadyTaken(
                r => r.Email,
                request);
        }

        internal void ShouldSatisfyUserNotFound<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyNotFound(
                UserExceptionErrorMessages.GetNotFoundMessage(
                    new(idPropertyExpression(request))));
        }

        internal void ShouldSatisfyUserNameNotFound<TRequest>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyNotFound(
                UserExceptionErrorMessages.GetNameNotFoundMessage(
                    new(namePropertyExpression(request))));
        }

        internal void ShouldSatisfyUserEmailAlreadyTaken<TRequest>(
            Func<TRequest, string> emailPropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                UserExceptionErrorMessages.GetEmailAlreadyTakenMessage(
                    new(emailPropertyExpression(request))));
        }

        internal void ShouldSatisfyUserNameAlreadyTaken<TRequest>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                UserExceptionErrorMessages.GetNameAlreadyTakenMessage(
                    new(namePropertyExpression(request))));
        }

        internal void ShouldSatisfyUserInvalidDetails<TRequest>(
            Func<TRequest, string> propertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                UserExceptionErrorMessages.GetInvalidDetailsMessage(
                    new(propertyExpression(request))));
        }

        internal void ShouldSatisfyUserEmailAlreadyConfirmed<TRequest>(
            Func<TRequest, string> propertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                UserExceptionErrorMessages.GetEmailAlreadyConfirmedMessage(
                    new(propertyExpression(request))));
        }

        internal void ShouldSatisfyUserEmailNotConfirmed<TRequest>(
            Func<TRequest, string> propertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyForbidden(
                UserExceptionErrorMessages.GetEmailNotConfirmedMessage(
                    new(propertyExpression(request))));
        }

        internal void ShouldSatisfyUserNameEmailNotConfirmed<TRequest>(
            Func<TRequest, string> propertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyForbidden(
                UserExceptionErrorMessages.GetNameEmailNotConfirmedMessage(
                    new(propertyExpression(request))));
        }
    }
}
