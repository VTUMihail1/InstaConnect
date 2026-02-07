using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostValidationAssertions
{
    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<UpdatePostCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<DeletePostCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        DeletePostCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForId(
        this TestValidationResult<GetPostByIdQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetPostByIdQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForContent(
        this TestValidationResult<AddPostCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddPostCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Content, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForContent(
        this TestValidationResult<UpdatePostCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Content, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForTitle(
        this TestValidationResult<GetAllPostsForUserQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostsForUserQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Title, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForTitle(
        this TestValidationResult<AddPostCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddPostCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Title, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForTitle(
        this TestValidationResult<UpdatePostCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Title, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForTitle(
        this TestValidationResult<GetAllPostsQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Title, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<GetAllPostsForUserQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostsForUserQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<AddPostCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        AddPostCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<UpdatePostCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserId(
        this TestValidationResult<DeletePostCommandRequest> result,
        IStringMessageTransformer messageTransformer,
        DeletePostCommandRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForCurrentUserId(
        this TestValidationResult<GetPostByIdQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetPostByIdQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForCurrentUserId(
        this TestValidationResult<GetAllPostsQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForCurrentUserId(
        this TestValidationResult<GetAllPostsForUserQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostsForUserQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForUserName(
        this TestValidationResult<GetAllPostsQueryRequest> result,
        IStringMessageTransformer messageTransformer,
        GetAllPostsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserName, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForPage(
        this TestValidationResult<GetAllPostsQueryRequest> result,
        IIntMessageTransformer messageTransformer,
        GetAllPostsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForPage(
        this TestValidationResult<GetAllPostsForUserQueryRequest> result,
        IIntMessageTransformer messageTransformer,
        GetAllPostsForUserQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForPageSize(
        this TestValidationResult<GetAllPostsQueryRequest> result,
        IIntMessageTransformer messageTransformer,
        GetAllPostsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForPageSize(
        this TestValidationResult<GetAllPostsForUserQueryRequest> result,
        IIntMessageTransformer messageTransformer,
        GetAllPostsForUserQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForSortOrder(
        this TestValidationResult<GetAllPostsQueryRequest> result,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForSortOrder(
        this TestValidationResult<GetAllPostsForUserQueryRequest> result,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostsForUserQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForSortTerm(
        this TestValidationResult<GetAllPostsQueryRequest> result,
        IEnumMessageTransformer<PostsSortTerm> messageTransformer,
        GetAllPostsQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
    }

    public static void ShouldHaveValidationErrorForSortTerm(
        this TestValidationResult<GetAllPostsForUserQueryRequest> result,
        IEnumMessageTransformer<PostsSortTerm> messageTransformer,
        GetAllPostsForUserQueryRequest request)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
    }
}
