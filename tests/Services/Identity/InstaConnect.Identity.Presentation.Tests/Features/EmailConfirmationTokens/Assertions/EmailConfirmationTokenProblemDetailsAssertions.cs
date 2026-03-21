using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyUserNameNotFound(
            AddEmailConfirmationTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserNameNotFound(
                r => r.Name,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            VerifyEmailConfirmationTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserEmailAlreadyConfirmed(
            VerifyEmailConfirmationTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserEmailAlreadyConfirmed(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyEmailConfirmationTokenNotFound(
            VerifyEmailConfirmationTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyEmailConfirmationTokenNotFound(
                r => r.Id,
                r => r.Value,
                request);
        }

        public void ShouldSatisfyEmailConfirmationTokenExpired(
            VerifyEmailConfirmationTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyEmailConfirmationTokenExpired(
                r => r.Id,
                r => r.Value,
                request);
        }

        internal void ShouldSatisfyEmailConfirmationTokenNotFound<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valuePropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyNotFound(
                EmailConfirmationTokenExceptionErrorMessages.GetNotFoundMessage(
                    new EmailConfirmationTokenId(
                        new UserId(idPropertyExpression(request)),
                        valuePropertyExpression(request))));
        }

        internal void ShouldSatisfyEmailConfirmationTokenExpired<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valuePropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                EmailConfirmationTokenExceptionErrorMessages.GetExpiredMessage(
                    new EmailConfirmationTokenId(
                        new UserId(idPropertyExpression(request)),
                        valuePropertyExpression(request))));
        }
    }
}
