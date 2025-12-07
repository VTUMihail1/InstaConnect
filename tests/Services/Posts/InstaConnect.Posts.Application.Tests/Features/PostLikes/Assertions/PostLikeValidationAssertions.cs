namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;
public static class PostLikeValidationAssertions
{
    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<DeletePostLikeCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        DeletePostLikeCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<GetPostLikeByIdQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetPostLikeByIdQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<AddPostLikeCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddPostLikeCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<GetAllPostLikesQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<GetPostLikeByIdQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetPostLikeByIdQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<AddPostLikeCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddPostLikeCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<DeletePostLikeCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        DeletePostLikeCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserName(
        this TestValidationResult<GetAllPostLikesQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserName, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForPage(
        this TestValidationResult<GetAllPostLikesQueryRequest> result,
        IIntMessageTransformer messageTransformer,
        GetAllPostLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForPageSize(
        this TestValidationResult<GetAllPostLikesQueryRequest> result,
        IIntMessageTransformer messageTransformer,
        GetAllPostLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForSortOrder(
        this TestValidationResult<GetAllPostLikesQueryRequest> result,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForSortProperty(
        this TestValidationResult<GetAllPostLikesQueryRequest> result,
        IEnumMessageTransformer<PostLikeSortProperty> messageTransformer,
        GetAllPostLikesQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.SortProperty, messageTransformer, request);
    }
}
