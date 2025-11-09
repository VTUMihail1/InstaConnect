namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentValidationAssertions
{
    public static void ShouldHaveValidationErrorForId(this TestValidationResult<AddPostCommentCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<UpdatePostCommentCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<DeletePostCommentCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<GetPostCommentByIdQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<GetAllPostCommentsQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForCommentId(this TestValidationResult<UpdatePostCommentCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CommentId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForCommentId(this TestValidationResult<DeletePostCommentCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CommentId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForCommentId(this TestValidationResult<GetPostCommentByIdQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CommentId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForContent(this TestValidationResult<AddPostCommentCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Content, errorMessage);
    }

    public static void ShouldHaveValidationErrorForContent(this TestValidationResult<UpdatePostCommentCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Content, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<AddPostCommentCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<UpdatePostCommentCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<DeletePostCommentCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<GetAllPostCommentsQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserName(this TestValidationResult<GetAllPostCommentsQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.UserName, errorMessage);
    }

    public static void ShouldHaveValidationErrorForPage(this TestValidationResult<GetAllPostCommentsQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Pagination.Page, errorMessage);
    }

    public static void ShouldHaveValidationErrorForPageSize(this TestValidationResult<GetAllPostCommentsQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Pagination.PageSize, errorMessage);
    }

    public static void ShouldHaveValidationErrorForSortOrder(this TestValidationResult<GetAllPostCommentsQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Sorting.Order, errorMessage);
    }

    public static void ShouldHaveValidationErrorForSortProperty(this TestValidationResult<GetAllPostCommentsQueryRequest> result, string errorMessage)
    {
        result
            .ShouldHaveValidationErrorForProperty(p => p.Sorting.Property, errorMessage);
    }
}
