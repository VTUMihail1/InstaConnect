using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.Tests.Assertions;

public static class ProblemDetailsAssertions
{
    public static void ShouldSatisfy(this ProblemDetails details, int statusCode)
    {
        details.ShouldSatisfy(d => d.Status == statusCode);
    }

    public static void ShouldSatisfy(this ProblemDetails details, int statusCode, string errorMessage)
    {
        details.ShouldSatisfy(d => d.Status == statusCode &&
                                   d.Detail == errorMessage);
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
}
