using InstaConnect.Common.Presentation.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostValidationProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyInvalidValidationForId(
        IStringMessageTransformer messageTransformer,
        UpdatePostApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            DeletePostApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            GetPostByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForContent(
            IStringMessageTransformer messageTransformer,
            AddPostApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Body.Content,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForContent(
            IStringMessageTransformer messageTransformer,
            UpdatePostApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Body.Content,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForTitle(
            IStringMessageTransformer messageTransformer,
            AddPostApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Body.Title,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForTitle(
            IStringMessageTransformer messageTransformer,
            UpdatePostApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Body.Title,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForTitle(
            IStringMessageTransformer messageTransformer,
            GetAllPostsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Title,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForTitle(
            IStringMessageTransformer messageTransformer,
            GetAllPostsForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Title,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetPostByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllPostsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllPostsForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForUserId(
            IStringMessageTransformer messageTransformer,
            GetAllPostsForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForUserId(
            IStringMessageTransformer messageTransformer,
            AddPostApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForUserId(
            IStringMessageTransformer messageTransformer,
            UpdatePostApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForUserId(
            IStringMessageTransformer messageTransformer,
            DeletePostApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForUserName(
            IStringMessageTransformer messageTransformer,
            GetAllPostsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.UserName,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPage(
            IIntMessageTransformer messageTransformer,
            GetAllPostsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Page,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPage(
            IIntMessageTransformer messageTransformer,
            GetAllPostsForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Page,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllPostsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.PageSize,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllPostsForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.PageSize,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllPostsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortOrder,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllPostsForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortOrder,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortTerm(
            IEnumMessageTransformer<PostsSortTerm> messageTransformer,
            GetAllPostsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortTerm,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortTerm(
            IEnumMessageTransformer<PostsForUserSortTerm> messageTransformer,
            GetAllPostsForUserApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortTerm,
                messageTransformer,
                request);
        }
    }
}
