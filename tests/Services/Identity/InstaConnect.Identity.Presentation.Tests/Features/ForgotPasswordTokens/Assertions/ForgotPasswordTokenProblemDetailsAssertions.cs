using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyUserInvalidDetails(
            AddForgotPasswordTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserInvalidDetails(
                r => r.Name,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            VerifyForgotPasswordTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyForgotPasswordTokenNotFound(
            VerifyForgotPasswordTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyForgotPasswordTokenNotFound(
                r => r.Id,
                r => r.Value,
                request);
        }

        public void ShouldSatisfyForgotPasswordTokenExpired(
            VerifyForgotPasswordTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyForgotPasswordTokenExpired(
                r => r.Id,
                r => r.Value,
                request);
        }

        internal void ShouldSatisfyForgotPasswordTokenNotFound<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valuePropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyNotFound(
                ForgotPasswordTokenExceptionErrorMessages.GetNotFoundMessage(
                    new ForgotPasswordTokenId(
                        new UserId(idPropertyExpression(request)),
                        valuePropertyExpression(request))));
        }

        internal void ShouldSatisfyForgotPasswordTokenExpired<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valuePropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                ForgotPasswordTokenExceptionErrorMessages.GetExpiredMessage(
                    new ForgotPasswordTokenId(
                        new UserId(idPropertyExpression(request)),
                        valuePropertyExpression(request))));
        }
    }
}
