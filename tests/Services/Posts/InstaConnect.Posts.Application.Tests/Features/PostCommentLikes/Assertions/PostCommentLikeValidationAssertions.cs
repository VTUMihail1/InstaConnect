namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeValidationAssertions
{
    extension(TestValidationResult<DeletePostCommentLikeCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForId(IStringMessageTransformer messageTransformer, DeletePostCommentLikeCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCommentId(IStringMessageTransformer messageTransformer, DeletePostCommentLikeCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForUserId(IStringMessageTransformer messageTransformer, DeletePostCommentLikeCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetPostCommentLikeByIdQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForId(IStringMessageTransformer messageTransformer, GetPostCommentLikeByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCommentId(IStringMessageTransformer messageTransformer, GetPostCommentLikeByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForUserId(IStringMessageTransformer messageTransformer, GetPostCommentLikeByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentUserId(IStringMessageTransformer messageTransformer, GetPostCommentLikeByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<AddPostCommentLikeCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForId(IStringMessageTransformer messageTransformer, AddPostCommentLikeCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCommentId(IStringMessageTransformer messageTransformer, AddPostCommentLikeCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForUserId(IStringMessageTransformer messageTransformer, AddPostCommentLikeCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetAllPostCommentLikesQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForId(IStringMessageTransformer messageTransformer, GetAllPostCommentLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCommentId(IStringMessageTransformer messageTransformer, GetAllPostCommentLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentUserId(IStringMessageTransformer messageTransformer, GetAllPostCommentLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForUserName(IStringMessageTransformer messageTransformer, GetAllPostCommentLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.UserName, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPage(IIntMessageTransformer messageTransformer, GetAllPostCommentLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPageSize(IIntMessageTransformer messageTransformer, GetAllPostCommentLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortOrder(IEnumMessageTransformer<CommonSortOrder> messageTransformer, GetAllPostCommentLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortTerm(IEnumMessageTransformer<PostCommentLikesSortTerm> messageTransformer, GetAllPostCommentLikesQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetAllPostCommentLikesForUserQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForUserId(IStringMessageTransformer messageTransformer, GetAllPostCommentLikesForUserQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentUserId(IStringMessageTransformer messageTransformer, GetAllPostCommentLikesForUserQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPage(IIntMessageTransformer messageTransformer, GetAllPostCommentLikesForUserQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPageSize(IIntMessageTransformer messageTransformer, GetAllPostCommentLikesForUserQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortOrder(IEnumMessageTransformer<CommonSortOrder> messageTransformer, GetAllPostCommentLikesForUserQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortTerm(IEnumMessageTransformer<PostCommentLikesForUserSortTerm> messageTransformer, GetAllPostCommentLikesForUserQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
        }
    }
}
