using FluentAssertions;

using FluentValidation.TestHelper;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;

public static class PostValidationAssertions
{
    public static void ShouldHaveValidationErrorForId(this TestValidationResult<UpdatePostCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<DeletePostCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<GetPostByIdQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForContent(this TestValidationResult<AddPostCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Content, errorMessage);
    }

    public static void ShouldHaveValidationErrorForContent(this TestValidationResult<UpdatePostCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Content, errorMessage);
    }

    public static void ShouldHaveValidationErrorForTitle(this TestValidationResult<AddPostCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Title, errorMessage);
    }

    public static void ShouldHaveValidationErrorForTitle(this TestValidationResult<UpdatePostCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Title, errorMessage);
    }

    public static void ShouldHaveValidationErrorForTitle(this TestValidationResult<GetAllPostsQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.Title, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<AddPostCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<UpdatePostCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<DeletePostCommandRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<GetAllPostsQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserName(this TestValidationResult<GetAllPostsQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.UserName, errorMessage);
    }

    public static void ShouldHaveValidationErrorForPage(this TestValidationResult<GetAllPostsQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Pagination.Page, errorMessage);
    }

    public static void ShouldHaveValidationErrorForPageSize(this TestValidationResult<GetAllPostsQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Pagination.PageSize, errorMessage);
    }

    public static void ShouldHaveValidationErrorForSortOrder(this TestValidationResult<GetAllPostsQueryRequest> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Sorting.Order, errorMessage);
    }

    public static void ShouldHaveValidationErrorForSortProperty(this TestValidationResult<GetAllPostsQueryRequest> result, string errorMessage)
    {
        result
            .ShouldHaveValidationErrorForProperty(p => p.Sorting.Property, errorMessage);
    }
}
