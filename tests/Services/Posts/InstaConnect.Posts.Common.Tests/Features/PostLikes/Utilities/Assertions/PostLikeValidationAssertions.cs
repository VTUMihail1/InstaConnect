using FluentValidation.TestHelper;

using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;

public static class PostLikeValidationAssertions
{
    public static void ShouldHaveValidationErrorForId(this TestValidationResult<DeletePostLikeCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<GetPostLikeByIdQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }
    public static void ShouldHaveValidationErrorForId(this TestValidationResult<AddPostLikeCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<GetAllPostLikesQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<GetPostLikeByIdQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<AddPostLikeCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<DeletePostLikeCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserName(this TestValidationResult<GetAllPostLikesQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.UserName, errorMessage);
    }

    public static void ShouldHaveValidationErrorForPage(this TestValidationResult<GetAllPostLikesQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Pagination.Page, errorMessage);
    }

    public static void ShouldHaveValidationErrorForPageSize(this TestValidationResult<GetAllPostLikesQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Pagination.PageSize, errorMessage);
    }

    public static void ShouldHaveValidationErrorForSortOrder(this TestValidationResult<GetAllPostLikesQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Sorting.Order, errorMessage);
    }

    public static void ShouldHaveValidationErrorForSortProperty(this TestValidationResult<GetAllPostLikesQueryRequest> result, string errorMessage)
    {
        result
            .ShouldHaveValidationErrorForProperty(p => p.Sorting.Property, errorMessage);
    }
}
