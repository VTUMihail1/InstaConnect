using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Assertions;

public static class UserProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyUserNotFound(
            UpdateCurrentUserApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            GetUserByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            GetUserDetailsByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            GetCurrentUserByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.CurrentId,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            GetCurrentUserDetailsByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.CurrentId,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            DeleteUserApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            DeleteCurrentUserApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.CurrentId,
                request);
        }

        public void ShouldSatisfyUserNameAlreadyTaken(
            AddUserApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNameAlreadyTaken(
                r => r.Form.Name,
                request);
        }

        public void ShouldSatisfyUserNameAlreadyTaken(
            UpdateCurrentUserApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNameAlreadyTaken(
                r => r.Form.Name,
                request);
        }

        public void ShouldSatisfyUserEmailAlreadyTaken(
            AddUserApiRequest request)
        {
            problemDetails.ShouldSatisfyUserEmailAlreadyTaken(
                r => r.Form.Email,
                request);
        }

        public void ShouldSatisfyUserEmailAlreadyTaken(
            UpdateCurrentUserApiRequest request)
        {
            problemDetails.ShouldSatisfyUserEmailAlreadyTaken(
                r => r.Form.Email,
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
            Func<TRequest, string> namePropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                UserExceptionErrorMessages.GetInvalidDetailsMessage(
                    new(namePropertyExpression(request))));
        }

        internal void ShouldSatisfyUserEmailAlreadyConfirmed<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                UserExceptionErrorMessages.GetEmailAlreadyConfirmedMessage(
                    new(idPropertyExpression(request))));
        }

        internal void ShouldSatisfyUserNameEmailAlreadyConfirmed<TRequest>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                UserExceptionErrorMessages.GetNameEmailAlreadyConfirmedMessage(
                    new(namePropertyExpression(request))));
        }

        internal void ShouldSatisfyUserEmailNotConfirmed<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                UserExceptionErrorMessages.GetEmailNotConfirmedMessage(
                    new(idPropertyExpression(request))));
        }

        internal void ShouldSatisfyUserNameEmailNotConfirmed<TRequest>(
            Func<TRequest, string> namePropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                UserExceptionErrorMessages.GetNameEmailNotConfirmedMessage(
                    new(namePropertyExpression(request))));
        }
    }
}
