using System.Linq.Expressions;
using System.Net;

using FluentAssertions;

using FluentValidation.Results;
using FluentValidation.TestHelper;

using InstaConnect.Common.Exceptions;

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

    public static void ShouldSatisfy(this ProblemDetails details, int statusCode)
    {
        details.ShouldSatisfy(d => d.Status == statusCode);
    }

    public static void ShouldSatisfy(this ProblemDetails details, int statusCode, string errorMessage)
    {
        details.ShouldSatisfy(d => d.Status == statusCode &&
                                   d.Detail == errorMessage);
    }

    public static void ShouldBeNull<T>(this T obj)
    {
        obj.Should().BeNull();
    }

    public static void ShouldBe<T>(this T obj, T value)
    {
        obj.Should().Be(value);
    }

    public static void ShouldBeTrue(this bool obj)
    {
        obj.Should().Be(true);
    }

    public static void ShouldBeFalse(this bool obj)
    {
        obj.Should().Be(false);
    }

    public static void ShouldBeOk(this HttpStatusCode statusCode)
    {
        statusCode.ShouldBe(HttpStatusCode.OK);
    }

    public static void ShouldBeBadRequest(this HttpStatusCode statusCode)
    {
        statusCode.ShouldBe(HttpStatusCode.BadRequest);
    }

    public static void ShouldBeNoContent(this HttpStatusCode statusCode)
    {
        statusCode.ShouldBe(HttpStatusCode.NoContent);
    }

    public static void ShouldBeNotFound(this HttpStatusCode statusCode)
    {
        statusCode.ShouldBe(HttpStatusCode.NotFound);
    }

    public static void ShouldBeUnauthorized(this HttpStatusCode statusCode)
    {
        statusCode.ShouldBe(HttpStatusCode.Unauthorized);
    }

    public static void ShouldBeForbidden(this HttpStatusCode statusCode)
    {
        statusCode.ShouldBe(HttpStatusCode.Forbidden);
    }

    public static void ShouldSatisfyBadRequest(this ProblemDetails problemDetails, string errorMessage)
    {
        problemDetails.ShouldSatisfy(StatusCodes.Status400BadRequest, errorMessage);
    }

    public static void ShouldSatisfyUnauthorized(this ProblemDetails problemDetails)
    {
        problemDetails.ShouldSatisfy(StatusCodes.Status401Unauthorized);
    }

    public static void ShouldSatisfyForbidden(this ProblemDetails problemDetails, string errorMessage)
    {
        problemDetails.ShouldSatisfy(StatusCodes.Status403Forbidden, errorMessage);
    }

    public static void ShouldSatisfyNotFound(this ProblemDetails problemDetails, string errorMessage)
    {
        problemDetails.ShouldSatisfy(StatusCodes.Status404NotFound, errorMessage);
    }

    public static void ShouldContain<T>(this IEnumerable<T> obj, Expression<Func<T, bool>> predicate)
    {
        obj.Should().Contain(predicate);
    }

    public static async Task ShouldThrowAsync<TException>(this Func<Task> action, string message)
        where TException : Exception
    {
        await action.Should().ThrowAsync<TException>().WithMessage(message);
    }

    public static async Task ShouldThrowInvalidValidationExceptionAsync(this Func<Task> action, string message)
    {
        await action.ShouldThrowAsync<InvalidValidationException>(message);
    }

    public static void ShouldHaveValidationErrorForProperty<T, TProperty>(this TestValidationResult<T> testValidationResult, Expression<Func<T, TProperty>> memberAccessor, string errorMessage)
    {
        testValidationResult
            .ShouldHaveValidationErrorFor(memberAccessor)
            .ShouldContain(p => p.ErrorMessage == errorMessage);
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
