using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyUserInvalidDetails(
            IssueRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyUserInvalidDetails(
                r => r.Name,
                request);
        }

        public void ShouldSatisfyUserNameEmailNotConfirmed(
            IssueRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNameEmailNotConfirmed(
                r => r.Name,
                request);
        }

        public void ShouldSatisfyUserEmailNotConfirmed(
            RotateRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyUserEmailNotConfirmed(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            RotateRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            DeleteCurrentRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyRefreshTokenNotFound(
            RotateRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyRefreshTokenNotFound(
                r => r.Id,
                r => r.Value,
                request);
        }

        public void ShouldSatisfyRefreshTokenNotFound(
            DeleteCurrentRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyRefreshTokenNotFound(
                r => r.Id,
                r => r.Value,
                request);
        }

        public void ShouldSatisfyRefreshTokenExpired(
            RotateRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyRefreshTokenExpired(
                r => r.Id,
                r => r.Value,
                request);
        }

        public void ShouldSatisfyRefreshTokenExpired(
            DeleteCurrentRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyRefreshTokenExpired(
                r => r.Id,
                r => r.Value,
                request);
        }

        internal void ShouldSatisfyRefreshTokenNotFound<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valuePropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyNotFound(
                RefreshTokenExceptionErrorMessages.GetNotFoundMessage(
                    new RefreshTokenId(
                        new UserId(idPropertyExpression(request)),
                        valuePropertyExpression(request))));
        }

        internal void ShouldSatisfyRefreshTokenExpired<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> valuePropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                RefreshTokenExceptionErrorMessages.GetExpiredMessage(
                    new RefreshTokenId(
                        new UserId(idPropertyExpression(request)),
                        valuePropertyExpression(request))));
        }
    }
}
