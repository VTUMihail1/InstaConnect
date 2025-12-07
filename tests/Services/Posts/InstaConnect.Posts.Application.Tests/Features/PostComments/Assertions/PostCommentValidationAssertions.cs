namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;
public static class PostCommentValidationAssertions
{
    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<AddPostCommentCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddPostCommentCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<UpdatePostCommentCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommentCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<DeletePostCommentCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<GetPostCommentByIdQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetPostCommentByIdQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<GetAllPostCommentsQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForCommentId(
        this TestValidationResult<UpdatePostCommentCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommentCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForCommentId(
        this TestValidationResult<DeletePostCommentCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForCommentId(
        this TestValidationResult<GetPostCommentByIdQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetPostCommentByIdQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForContent(
        this TestValidationResult<AddPostCommentCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddPostCommentCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Content, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForContent(
        this TestValidationResult<UpdatePostCommentCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommentCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Content, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<AddPostCommentCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddPostCommentCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<UpdatePostCommentCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommentCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<DeletePostCommentCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<GetAllPostCommentsQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserName(
        this TestValidationResult<GetAllPostCommentsQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserName, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForPage(
        this TestValidationResult<GetAllPostCommentsQueryRequest> result,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForPageSize(
        this TestValidationResult<GetAllPostCommentsQueryRequest> result,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForSortOrder(
        this TestValidationResult<GetAllPostCommentsQueryRequest> result,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostCommentsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForSortProperty(
        this TestValidationResult<GetAllPostCommentsQueryRequest> result,
        IEnumMessageTransformer<PostCommentSortProperty> messageTransformer,
        GetAllPostCommentsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.SortProperty, messageTransformer, request);
    }
}
