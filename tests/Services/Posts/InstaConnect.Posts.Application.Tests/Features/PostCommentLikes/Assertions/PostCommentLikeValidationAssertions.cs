namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeValidationAssertions
{
    public static void ShouldHaveValidationErrorForId(this TestValidationResult<DeletePostCommentLikeCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<GetPostCommentLikeByIdQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }
    public static void ShouldHaveValidationErrorForId(this TestValidationResult<AddPostCommentLikeCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<GetAllPostCommentLikesQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForCommentId(this TestValidationResult<DeletePostCommentLikeCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CommentId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForCommentId(this TestValidationResult<GetPostCommentLikeByIdQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CommentId, errorMessage);
    }
    public static void ShouldHaveValidationErrorForCommentId(this TestValidationResult<AddPostCommentLikeCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CommentId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForCommentId(this TestValidationResult<GetAllPostCommentLikesQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.CommentId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<GetPostCommentLikeByIdQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<AddPostCommentLikeCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<DeletePostCommentLikeCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserName(this TestValidationResult<GetAllPostCommentLikesQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.UserName, errorMessage);
    }

    public static void ShouldHaveValidationErrorForPage(this TestValidationResult<GetAllPostCommentLikesQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Pagination.Page, errorMessage);
    }

    public static void ShouldHaveValidationErrorForPageSize(this TestValidationResult<GetAllPostCommentLikesQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Pagination.PageSize, errorMessage);
    }

    public static void ShouldHaveValidationErrorForSortOrder(this TestValidationResult<GetAllPostCommentLikesQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Sorting.Order, errorMessage);
    }

    public static void ShouldHaveValidationErrorForSortProperty(this TestValidationResult<GetAllPostCommentLikesQueryRequest> result, string errorMessage)
    {
        result
            .ShouldHaveValidationErrorForProperty(p => p.Sorting.Property, errorMessage);
    }
}
