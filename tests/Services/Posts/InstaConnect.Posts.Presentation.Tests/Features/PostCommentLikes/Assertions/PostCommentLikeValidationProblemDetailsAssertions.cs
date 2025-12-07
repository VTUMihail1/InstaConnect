using InstaConnect.Common.Presentation.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeValidationProblemDetailsAssertions
{
    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetPostCommentLikeByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        AddPostCommentLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForCommentId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.CommentId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForCommentId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetPostCommentLikeByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.CommentId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForCommentId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        AddPostCommentLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.CommentId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForCommentId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.CommentId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        DeletePostCommentLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetPostCommentLikeByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        AddPostCommentLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserName(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostCommentLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserName,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForPage(
        this ApplicationProblemDetails problemDetails,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Page,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForPageSize(
        this ApplicationProblemDetails problemDetails,
        IIntMessageTransformer messageTransformer,
        GetAllPostCommentLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.PageSize,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForSortOrder(
        this ApplicationProblemDetails problemDetails,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostCommentLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.SortOrder,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForSortProperty(
        this ApplicationProblemDetails problemDetails,
        IEnumMessageTransformer<PostCommentLikeSortProperty> messageTransformer,
        GetAllPostCommentLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.SortProperty,
            messageTransformer,
            request);
    }
}
