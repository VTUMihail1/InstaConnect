using InstaConnect.Common.Presentation.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostValidationProblemDetailsAssertions
{
    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        UpdatePostApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        DeletePostApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetPostByIdApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Id,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForContent(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        AddPostApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Body.Content,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForContent(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        UpdatePostApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Body.Content,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForTitle(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        AddPostApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Body.Title,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForTitle(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        UpdatePostApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Body.Title,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForTitle(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Title,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForTitle(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Title,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForCurrentUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetPostByIdApiRequest request)
    {
         problemDetails.ShouldSatisfyInvalidValidation(
             p => p.CurrentUserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForCurrentUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.CurrentUserId,
           messageTransformer,
           request);
    }

    public static void ShouldSatisfyInvalidValidationForCurrentUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.CurrentUserId,
           messageTransformer,
           request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        AddPostApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        UpdatePostApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserId(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        DeletePostApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserId,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForUserName(
        this ApplicationProblemDetails problemDetails,
        IStringMessageTransformer messageTransformer,
        GetAllPostsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.UserName,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForPage(
        this ApplicationProblemDetails problemDetails,
        IIntMessageTransformer messageTransformer,
        GetAllPostsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Page,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForPage(
        this ApplicationProblemDetails problemDetails,
        IIntMessageTransformer messageTransformer,
        GetAllPostsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.Page,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForPageSize(
        this ApplicationProblemDetails problemDetails,
        IIntMessageTransformer messageTransformer,
        GetAllPostsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.PageSize,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForPageSize(
        this ApplicationProblemDetails problemDetails,
        IIntMessageTransformer messageTransformer,
        GetAllPostsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.PageSize,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForSortOrder(
        this ApplicationProblemDetails problemDetails,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.SortOrder,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForSortOrder(
        this ApplicationProblemDetails problemDetails,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer,
        GetAllPostsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.SortOrder,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForSortProperty(
        this ApplicationProblemDetails problemDetails,
        IEnumMessageTransformer<PostsSortTerm> messageTransformer,
        GetAllPostsApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.SortTerm,
            messageTransformer,
            request);
    }

    public static void ShouldSatisfyInvalidValidationForSortProperty(
        this ApplicationProblemDetails problemDetails,
        IEnumMessageTransformer<PostsSortTerm> messageTransformer,
        GetAllPostsForUserApiRequest request)
    {
        problemDetails.ShouldSatisfyInvalidValidation(
            p => p.SortTerm,
            messageTransformer,
            request);
    }
}
