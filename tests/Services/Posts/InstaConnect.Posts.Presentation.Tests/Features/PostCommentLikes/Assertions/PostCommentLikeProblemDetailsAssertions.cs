using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyUserNotFound(
        AddPostCommentLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.UserId,
                request);
        }

        public void ShouldSatisfyUserNotFound(
            GetAllPostCommentLikesForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyUserNotFound(
                r => r.UserId,
                request);
        }

        public void ShouldSatisfyPostNotFound(
            AddPostCommentLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyPostNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyPostNotFound(
            DeletePostCommentLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyPostNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyPostNotFound(
            GetPostCommentLikeByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyPostNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyPostNotFound(
            GetAllPostCommentLikesApiRequest request)
        {
            problemDetails.ShouldSatisfyPostNotFound(
                r => r.Id,
                request);
        }

        public void ShouldSatisfyPostCommentNotFound(
            AddPostCommentLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyPostCommentNotFound(
                r => r.Id,
                r => r.CommentId,
                request);
        }

        public void ShouldSatisfyPostCommentNotFound(
            DeletePostCommentLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyPostCommentNotFound(
                r => r.Id,
                r => r.CommentId,
                request);
        }

        public void ShouldSatisfyPostCommentNotFound(
            GetPostCommentLikeByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyPostCommentNotFound(
                r => r.Id,
                r => r.CommentId,
                request);
        }

        public void ShouldSatisfyPostCommentNotFound(
            GetAllPostCommentLikesApiRequest request)
        {
            problemDetails.ShouldSatisfyPostCommentNotFound(
                r => r.Id,
                r => r.CommentId,
                request);
        }

        public void ShouldSatisfyPostCommentLikeNotFound(
            DeletePostCommentLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyPostCommentLikeNotFound(
                r => r.Id,
                r => r.CommentId,
                r => r.UserId,
                request);
        }

        public void ShouldSatisfyPostCommentLikeNotFound(
            GetPostCommentLikeByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyPostCommentLikeNotFound(
                r => r.Id,
                r => r.CommentId,
                r => r.UserId,
                request);
        }

        public void ShouldSatisfyPostCommentLikeAlreadyExists(
            AddPostCommentLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyPostCommentLikeAlreadyExists(
                r => r.Id,
                r => r.CommentId,
                r => r.UserId,
                request);
        }

        internal void ShouldSatisfyPostCommentLikeNotFound<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> commentIdPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyNotFound(
                PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(
                    new(
                        new(
                            new(idPropertyExpression(request)),
                            commentIdPropertyExpression(request)),
                        new(userIdPropertyExpression(request)))));
        }

        internal void ShouldSatisfyPostCommentLikeAlreadyExists<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> commentIdPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request)
        {
            problemDetails.ShouldSatisfyBadRequest(
                PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(
                    new(
                        new(
                            new(idPropertyExpression(request)),
                            commentIdPropertyExpression(request)),
                        new(userIdPropertyExpression(request)))));
        }
    }
}
