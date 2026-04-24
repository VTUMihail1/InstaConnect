using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeValidationProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyInvalidValidationForId(
        IStringMessageTransformer messageTransformer,
        DeletePostCommentLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            GetPostCommentLikeByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            AddPostCommentLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            GetAllPostCommentLikesApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCommentId(
            IStringMessageTransformer messageTransformer,
            DeletePostCommentLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CommentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCommentId(
            IStringMessageTransformer messageTransformer,
            GetPostCommentLikeByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CommentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCommentId(
            IStringMessageTransformer messageTransformer,
            AddPostCommentLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CommentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCommentId(
            IStringMessageTransformer messageTransformer,
            GetAllPostCommentLikesApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CommentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetPostCommentLikeByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllPostCommentLikesApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllPostCommentLikesForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForUserId(
            IStringMessageTransformer messageTransformer,
            GetAllPostCommentLikesForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForUserId(
            IStringMessageTransformer messageTransformer,
            DeletePostCommentLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForUserId(
            IStringMessageTransformer messageTransformer,
            GetPostCommentLikeByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForUserId(
            IStringMessageTransformer messageTransformer,
            AddPostCommentLikeApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForUserName(
            IStringMessageTransformer messageTransformer,
            GetAllPostCommentLikesApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserName,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPage(
            IIntMessageTransformer messageTransformer,
            GetAllPostCommentLikesApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Page,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPage(
            IIntMessageTransformer messageTransformer,
            GetAllPostCommentLikesForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Page,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllPostCommentLikesApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.PageSize,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllPostCommentLikesForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.PageSize,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllPostCommentLikesApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortOrder,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllPostCommentLikesForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortOrder,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortTerm(
            IEnumMessageTransformer<PostCommentLikesSortTerm> messageTransformer,
            GetAllPostCommentLikesApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortTerm,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortTerm(
            IEnumMessageTransformer<PostCommentLikesForUserSortTerm> messageTransformer,
            GetAllPostCommentLikesForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortTerm,
                messageTransformer,
                request);
        }
    }
}
