using InstaConnect.Common.Presentation.Models;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeValidationProblemDetailsAssertions
{
    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        DeletePostLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetPostLikeByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        AddPostLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetPostLikeByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        AddPostLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        DeletePostLikeApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserName(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserName,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForPage(
        this ApplicationProblemDetails problemDetails,
        IIntMessageTransformer messageTransformer,
        GetAllPostLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Page,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForPageSize(
        this ApplicationProblemDetails problemDetails,
        IIntMessageTransformer messageTransformer,
        GetAllPostLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.PageSize,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForSortOrder(
        this ApplicationProblemDetails problemDetails,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.SortOrder,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForSortProperty(
        this ApplicationProblemDetails problemDetails,
        IEnumMessageTransformer<PostLikeSortProperty> messageTransformer,
        GetAllPostLikesApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.SortProperty,
            messageTransformer,
            request);
    }
}
