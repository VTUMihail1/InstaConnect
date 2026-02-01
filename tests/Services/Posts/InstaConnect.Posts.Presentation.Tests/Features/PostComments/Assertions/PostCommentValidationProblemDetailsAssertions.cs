using InstaConnect.Common.Presentation.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentValidationProblemDetailsAssertions
{
    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        AddPostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetPostCommentByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForCommentId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.CommentId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForCommentId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.CommentId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForCommentId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetPostCommentByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.CommentId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForContent(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        AddPostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Body.Content,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForContent(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Body.Content,
            messageTransformer,
            request);
    }

    public static async Task ShouldSatisfyInvalidValidationForCurrentUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetPostCommentByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.CurrentUserId,
           messageTransformer,
           request);
    }

    public static async Task ShouldSatisfyInvalidValidationForCurrentUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.CurrentUserId,
           messageTransformer,
           request);
    }

    public static async Task ShouldSatisfyInvalidValidationForCurrentUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.CurrentUserId,
           messageTransformer,
           request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        AddPostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        UpdatePostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserName(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserName,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForPage(
        this ApplicationProblemDetails problemDetails,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Page,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForPage(
        this ApplicationProblemDetails problemDetails,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Page,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForPageSize(
        this ApplicationProblemDetails problemDetails,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.PageSize,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForPageSize(
        this ApplicationProblemDetails problemDetails,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.PageSize,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForSortOrder(
        this ApplicationProblemDetails problemDetails,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostCommentsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.SortOrder,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForSortOrder(
        this ApplicationProblemDetails problemDetails,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostCommentsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.SortOrder,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForSortProperty(
        this ApplicationProblemDetails problemDetails,
        IEnumMessageTransformer<PostCommentsSortTerm> messageTransformer,
        GetAllPostCommentsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.SortTerm,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForSortProperty(
        this ApplicationProblemDetails problemDetails,
        IEnumMessageTransformer<PostCommentsSortTerm> messageTransformer,
        GetAllPostCommentsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.SortTerm,
            messageTransformer,
            request);
    }
}
