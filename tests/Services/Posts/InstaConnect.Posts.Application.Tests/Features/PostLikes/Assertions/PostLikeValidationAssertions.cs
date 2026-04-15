namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeValidationAssertions
{
    extension(TestValidationResult<DeletePostLikeCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
        IStringMessageTransformer messageTransformer,
        DeletePostLikeCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForUserId(
            IStringMessageTransformer messageTransformer,
            DeletePostLikeCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetPostLikeByIdQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
        IStringMessageTransformer messageTransformer,
        GetPostLikeByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForUserId(
            IStringMessageTransformer messageTransformer,
            GetPostLikeByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetPostLikeByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<AddPostLikeCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
        IStringMessageTransformer messageTransformer,
        AddPostLikeCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForUserId(
            IStringMessageTransformer messageTransformer,
            AddPostLikeCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetAllPostLikesQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
        IStringMessageTransformer messageTransformer,
        GetAllPostLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllPostLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForUserName(
            IStringMessageTransformer messageTransformer,
            GetAllPostLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.UserName, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPage(
            IIntMessageTransformer messageTransformer,
            GetAllPostLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllPostLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllPostLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortTerm(
            IEnumMessageTransformer<PostLikesSortTerm> messageTransformer,
            GetAllPostLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetAllPostLikesForUserQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForUserId(
        IStringMessageTransformer messageTransformer,
        GetAllPostLikesForUserQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllPostLikesForUserQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPage(
            IIntMessageTransformer messageTransformer,
            GetAllPostLikesForUserQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllPostLikesForUserQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllPostLikesForUserQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortTerm(
            IEnumMessageTransformer<PostLikesForUserSortTerm> messageTransformer,
            GetAllPostLikesForUserQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
        }
    }
}
