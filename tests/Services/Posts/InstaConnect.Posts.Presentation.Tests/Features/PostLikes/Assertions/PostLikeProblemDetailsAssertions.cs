using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyUserNotFound(
        AddPostLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.UserId,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            GetAllPostLikesForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.UserId,
                request);
        }

        public void ShouldSatisfyPostNotFound(
            AddPostLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyPostNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyPostNotFound(
            DeletePostLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyPostNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyPostNotFound(
            GetPostLikeByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyPostNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyPostNotFound(
            GetAllPostLikesApiRequest request)
        {
            problemDetails.ShouldSatisfyPostNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyPostLikeNotFound(
            DeletePostLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyPostLikeNotFound(
                r => r.Id,
                r => r.UserId,
                request);
        }

        public void ShouldSatisfyPostLikeNotFound(
            GetPostLikeByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyPostLikeNotFound(
                r => r.Id,
                r => r.UserId,
                request);
        }

        public void ShouldSatisfyPostLikeAlreadyExists(
            AddPostLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyPostLikeAlreadyExists(
                r => r.Id,
                r => r.UserId,
                request);
        }

        internal void ShouldSatisfyPostLikeNotFound<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyNotFound(
                PostLikeExceptionErrorMessages.GetNotFoundMessage(
                    new(
                        new(idPropertyExpression(request)),
                        new(userIdPropertyExpression(request)))));
        }

        internal void ShouldSatisfyPostLikeAlreadyExists<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(
                    new(
                        new(idPropertyExpression(request)),
                        new(userIdPropertyExpression(request)))));
        }
    }
}
