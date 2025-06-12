using System.Linq.Expressions;

using FluentAssertions;

using FluentValidation.TestHelper;

using InstaConnect.Common.Exceptions.Base;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NSubstitute;

namespace InstaConnect.Common.Tests.Utilities;
public static class Assertions
{
    public static void ShouldSatisfy<T>(this T obj, Expression<Func<T, bool>> predicate)
    {
        obj.Should().Match(predicate);
    }

    public static void ShouldBeNull<T>(this T obj)
    {
        obj.Should().BeNull();
    }

    public static async Task ShouldThrowAsync<TException>(this Func<Task> action)
        where TException : Exception
    {
        await action.Should().ThrowAsync<TException>();
    }

    public static async Task ShouldThrowValidationExceptionAsync(this Func<Task> action)
    {
        await action.Should().ThrowAsync<AppValidationException>();
    }

    public static void ShouldHaveValidationErrorForProperty<T, TProperty>(this TestValidationResult<T> testValidationResult, Expression<Func<T, TProperty>> memberAccessor)
    {
        testValidationResult.ShouldHaveValidationErrorFor(memberAccessor);
    }

    public static void ShouldNotHaveAnyValidationErrorProperties<T>(this TestValidationResult<T> testValidationResult)
    {
        testValidationResult.ShouldNotHaveAnyValidationErrors();
    }

    public static T ShouldHaveReceived<T>(this T substitute, int numberOfCalls) where T : class
    {
        return substitute.Received(numberOfCalls);
    }

    public static void ShouldBeActionResultAndSatisfy<T>(this ActionResult<T> actionResult, Expression<Func<T, bool>> predicate)
        where T : class
    {
        actionResult.Result
            .Should()
            .BeOfType<ObjectResult>()
            .Which
            .Value
            .Should()
            .Match(predicate);
    }

    internal static void ShouldBeActionResultWithStatusCode<T>(this ActionResult<T> actionResult, int statusCode)
        where T : class
    {
        actionResult
            .Result
            .Should()
            .Match<ObjectResult>(m => m.StatusCode == statusCode);
    }

    internal static void ShouldBeActionResultWithStatusCode(this ActionResult actionResult, int statusCode)
    {
        actionResult
            .Should()
            .Match<StatusCodeResult>(m => m.StatusCode == statusCode);
    }

    public static void ShouldBeActionResultWithOkStatusCode<T>(this ActionResult<T> actionResult)
        where T : class
    {
        actionResult.ShouldBeActionResultWithStatusCode(StatusCodes.Status200OK);
    }

    public static void ShouldBeActionResultWithNoContentStatusCode(this ActionResult actionResult)
    {
        actionResult.ShouldBeActionResultWithStatusCode(StatusCodes.Status204NoContent);
    }

    public static void ShouldBeActionResultWithNotFoundStatusCode(this ActionResult actionResult)
    {
        actionResult.ShouldBeActionResultWithStatusCode(StatusCodes.Status404NotFound);
    }

    public static void ShouldBeActionResultWithBadRequestStatusCode(this ActionResult actionResult)
    {
        actionResult.ShouldBeActionResultWithStatusCode(StatusCodes.Status400BadRequest);
    }

    public static void ShouldBeActionResultWithUnathorizedStatusCode(this ActionResult actionResult)
    {
        actionResult.ShouldBeActionResultWithStatusCode(StatusCodes.Status401Unauthorized);
    }

    public static void ShouldBeActionResultWithForbiddenStatusCode(this ActionResult actionResult)
    {
        actionResult.ShouldBeActionResultWithStatusCode(StatusCodes.Status403Forbidden);
    }
}
