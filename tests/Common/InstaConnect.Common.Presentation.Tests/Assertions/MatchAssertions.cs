using System.Linq.Expressions;
using System.Net;

using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.Tests.Assertions;

public static class MatchAssertions
{
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

    public static void ShouldBeActionResultAndSatisfy<T>(this ActionResult<T> actionResult, Expression<Func<T, bool>> predicate)
        where T : class
    {
        actionResult.Result
            .Should()
            .BeOfType<OkObjectResult>()
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
