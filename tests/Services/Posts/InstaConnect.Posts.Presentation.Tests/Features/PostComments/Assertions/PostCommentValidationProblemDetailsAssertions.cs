using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentValidationProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyInvalidValidationForId(
        IStringMessageTransformer messageTransformer,
        AddPostCommentApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            UpdatePostCommentApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            DeletePostCommentApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            GetPostCommentByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            GetAllPostCommentsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCommentId(
            IStringMessageTransformer messageTransformer,
            UpdatePostCommentApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CommentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCommentId(
            IStringMessageTransformer messageTransformer,
            DeletePostCommentApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CommentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCommentId(
            IStringMessageTransformer messageTransformer,
            GetPostCommentByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CommentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForContent(
            IStringMessageTransformer messageTransformer,
            AddPostCommentApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Body.Content,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForContent(
            IStringMessageTransformer messageTransformer,
            UpdatePostCommentApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Body.Content,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetPostCommentByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllPostCommentsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllPostCommentsForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForUserId(
            IStringMessageTransformer messageTransformer,
            GetAllPostCommentsForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForUserId(
            IStringMessageTransformer messageTransformer,
            AddPostCommentApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForUserId(
            IStringMessageTransformer messageTransformer,
            UpdatePostCommentApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForUserId(
            IStringMessageTransformer messageTransformer,
            DeletePostCommentApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForUserName(
            IStringMessageTransformer messageTransformer,
            GetAllPostCommentsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserName,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPage(
            IIntMessageTransformer messageTransformer,
            GetAllPostCommentsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Page,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPage(
            IIntMessageTransformer messageTransformer,
            GetAllPostCommentsForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Page,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllPostCommentsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.PageSize,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllPostCommentsForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.PageSize,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllPostCommentsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortOrder,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllPostCommentsForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortOrder,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortTerm(
            IEnumMessageTransformer<PostCommentsSortTerm> messageTransformer,
            GetAllPostCommentsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortTerm,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortTerm(
            IEnumMessageTransformer<PostCommentsForUserSortTerm> messageTransformer,
            GetAllPostCommentsForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortTerm,
                messageTransformer,
                request);
        }
    }
}
