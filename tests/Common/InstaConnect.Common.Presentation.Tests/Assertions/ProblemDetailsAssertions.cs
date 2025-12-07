using System.Linq.Expressions;

using InstaConnect.Common.Domain.Utilities;
using InstaConnect.Common.Presentation.Models;
using InstaConnect.Common.Tests.DataAttributes.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.Tests.Assertions;

public static class ProblemDetailsAssertions
{
    internal static void ShouldSatisfy(this ApplicationProblemDetails problemDetails, int statusCode)
    {
        problemDetails.ShouldSatisfy(d => d.Status == statusCode);
    }

    internal static void ShouldSatisfy(this ApplicationProblemDetails problemDetails, int statusCode, string errorMessage)
    {
        problemDetails.ShouldSatisfy(d => d.Status == statusCode &&
                                          d.Detail == errorMessage);
    }

    public static void ShouldSatisfyInvalidValidation<TRequest, TProperty>(
        this ApplicationProblemDetails problemDetails,
        Expression<Func<TRequest, TProperty>> propertyExpression,
        IMessageTransformer<TProperty> messageTransformer,
        TRequest request)
    {
        problemDetails.ShouldSatisfy(d => d.Status == StatusCodes.Status400BadRequest &&
                                   d.Detail == CommonExceptionErrorMessages.GetInvalidValidation() &&
                                   d.Errors!.All(e => e == messageTransformer.Transform(propertyExpression, propertyExpression.Compile()(request))));
    }

    public static void ShouldSatisfyBadRequest(
        this ApplicationProblemDetails problemDetails,
        string errorMessage)
    {
        problemDetails.ShouldSatisfy(
            StatusCodes.Status400BadRequest,
            errorMessage);
    }

    public static void ShouldSatisfyForbidden(
        this ApplicationProblemDetails problemDetails,
        string errorMessage)
    {
        problemDetails.ShouldSatisfy(
            StatusCodes.Status403Forbidden,
            errorMessage);
    }

    public static void ShouldSatisfyNotFound(
        this ApplicationProblemDetails problemDetails,
        string errorMessage)
    {
        problemDetails.ShouldSatisfy(
            StatusCodes.Status404NotFound,
            errorMessage);
    }
}
