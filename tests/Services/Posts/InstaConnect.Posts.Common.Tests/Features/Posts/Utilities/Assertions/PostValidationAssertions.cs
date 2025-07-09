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
    public static void ShouldHaveValidationErrorForId(this TestValidationResult<UpdatePostCommand> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<DeletePostCommand> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<GetPostByIdQuery> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Id, errorMessage);
    }

    public static void ShouldHaveValidationErrorForContent(this TestValidationResult<AddPostCommand> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Content, errorMessage);
    }

    public static void ShouldHaveValidationErrorForContent(this TestValidationResult<UpdatePostCommand> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Content, errorMessage);
    }

    public static void ShouldHaveValidationErrorForTitle(this TestValidationResult<AddPostCommand> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Title, errorMessage);
    }

    public static void ShouldHaveValidationErrorForTitle(this TestValidationResult<UpdatePostCommand> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Title, errorMessage);
    }

    public static void ShouldHaveValidationErrorForTitle(this TestValidationResult<GetAllPostsQuery> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.Title, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<AddPostCommand> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<UpdatePostCommand> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<DeletePostCommand> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<GetAllPostsQuery> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.UserId, errorMessage);
    }

    public static void ShouldHaveValidationErrorForUserName(this TestValidationResult<GetAllPostsQuery> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Filter.UserName, errorMessage);
    }

    public static void ShouldHaveValidationErrorForPage(this TestValidationResult<GetAllPostsQuery> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Pagination.Page, errorMessage);
    }

    public static void ShouldHaveValidationErrorForPageSize(this TestValidationResult<GetAllPostsQuery> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Pagination.PageSize, errorMessage);
    }

    public static void ShouldHaveValidationErrorForSortOrder(this TestValidationResult<GetAllPostsQuery> result, string errorMessage)
    {
        result.ShouldHaveValidationErrorForProperty(p => p.Sorting.Order, errorMessage);
    }

    public static void ShouldHaveValidationErrorForSortProperty(this TestValidationResult<GetAllPostsQuery> result, string errorMessage)
    {
        result
            .ShouldHaveValidationErrorForProperty(p => p.Sorting.Property, errorMessage);
    }
}
