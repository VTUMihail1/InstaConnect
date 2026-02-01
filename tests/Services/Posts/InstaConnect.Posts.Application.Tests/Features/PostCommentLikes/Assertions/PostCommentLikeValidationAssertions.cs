namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeValidationAssertions
{
    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<DeletePostCommentLikeCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentLikeCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<GetPostCommentLikeByIdQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetPostCommentLikeByIdQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<AddPostCommentLikeCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddPostCommentLikeCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<GetAllPostCommentLikesQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForCommentId(
        this TestValidationResult<DeletePostCommentLikeCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentLikeCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForCommentId(
        this TestValidationResult<GetPostCommentLikeByIdQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetPostCommentLikeByIdQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForCommentId(
        this TestValidationResult<AddPostCommentLikeCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddPostCommentLikeCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForCommentId(
        this TestValidationResult<GetAllPostCommentLikesQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CommentId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<GetPostCommentLikeByIdQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetPostCommentLikeByIdQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<GetAllPostCommentLikesForUserQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesForUserQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<AddPostCommentLikeCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddPostCommentLikeCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<DeletePostCommentLikeCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentLikeCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForCurrentUserId(
        this TestValidationResult<GetPostCommentLikeByIdQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetPostCommentLikeByIdQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForCurrentUserId(
        this TestValidationResult<GetAllPostCommentLikesQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForCurrentUserId(
        this TestValidationResult<GetAllPostCommentLikesForUserQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesForUserQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserName(
        this TestValidationResult<GetAllPostCommentLikesQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserName, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForPage(
        this TestValidationResult<GetAllPostCommentLikesQueryRequest> result,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForPage(
        this TestValidationResult<GetAllPostCommentLikesForUserQueryRequest> result,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentLikesForUserQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForPageSize(
        this TestValidationResult<GetAllPostCommentLikesQueryRequest> result,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForPageSize(
        this TestValidationResult<GetAllPostCommentLikesForUserQueryRequest> result,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentLikesForUserQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForSortOrder(
        this TestValidationResult<GetAllPostCommentLikesQueryRequest> result,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostCommentLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForSortOrder(
        this TestValidationResult<GetAllPostCommentLikesForUserQueryRequest> result,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostCommentLikesForUserQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForSortProperty(
        this TestValidationResult<GetAllPostCommentLikesQueryRequest> result,
        IEnumMessageTransformer<PostCommentLikesSortTerm> messageTransformer,
        GetAllPostCommentLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForSortProperty(
        this TestValidationResult<GetAllPostCommentLikesForUserQueryRequest> result,
        IEnumMessageTransformer<PostCommentLikesSortTerm> messageTransformer,
        GetAllPostCommentLikesForUserQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
    }
}
