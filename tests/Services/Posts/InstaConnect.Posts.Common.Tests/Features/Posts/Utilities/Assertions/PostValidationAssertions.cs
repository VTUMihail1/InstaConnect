using FluentValidation.TestHelper;

using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;

public static class PostValidationAssertions
{
    public static void ShouldHaveValidationErrorForId(this TestValidationResult<UpdatePostCommand> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Id);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<DeletePostCommand> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Id);
    }

    public static void ShouldHaveValidationErrorForId(this TestValidationResult<GetPostByIdQuery> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Id);
    }

    public static void ShouldHaveValidationErrorForContent(this TestValidationResult<AddPostCommand> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Content);
    }

    public static void ShouldHaveValidationErrorForContent(this TestValidationResult<UpdatePostCommand> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Content);
    }

    public static void ShouldHaveValidationErrorForTitle(this TestValidationResult<AddPostCommand> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Title);
    }

    public static void ShouldHaveValidationErrorForTitle(this TestValidationResult<UpdatePostCommand> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Title);
    }

    public static void ShouldHaveValidationErrorForTitle(this TestValidationResult<GetAllPostsQuery> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Filter.Title);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<AddPostCommand> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.CurrentUserId);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<UpdatePostCommand> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.CurrentUserId);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<DeletePostCommand> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.CurrentUserId);
    }

    public static void ShouldHaveValidationErrorForUserId(this TestValidationResult<GetAllPostsQuery> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Filter.UserId);
    }

    public static void ShouldHaveValidationErrorForUserName(this TestValidationResult<GetAllPostsQuery> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Filter.UserName);
    }

    public static void ShouldHaveValidationErrorForPage(this TestValidationResult<GetAllPostsQuery> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Pagination.Page);
    }

    public static void ShouldHaveValidationErrorForPageSize(this TestValidationResult<GetAllPostsQuery> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Pagination.PageSize);
    }

    public static void ShouldHaveValidationErrorForSortOrder(this TestValidationResult<GetAllPostsQuery> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Sorting.Order);
    }

    public static void ShouldHaveValidationErrorForSortProperty(this TestValidationResult<GetAllPostsQuery> result)
    {
        result.ShouldHaveValidationErrorFor(p => p.Sorting.Property);
    }
}
