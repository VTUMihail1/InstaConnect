using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;

using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Tests.Utilities;
public static class Verifiers
{
    public static bool IsSatisfied(this ProblemDetails details, int statusCode)
    {
        return details.Status == statusCode;
    }

    public static bool IsSatisfied(this ProblemDetails details, int statusCode, string errorMessage)
    {
        return details.Status == statusCode && details.Detail == errorMessage;
    }

    public static bool IsSatisfied(this ValidationFailure failure, string errorMessage)
    {
        return failure.ErrorMessage == errorMessage;
    }

    public static bool IsSatisfied(this ObjectResult objectResult, int statusCode)
    {
        return objectResult.StatusCode == statusCode;
    }

    public static bool IsSatisfied(this StatusCodeResult statusCodeResult, int statusCode)
    {
        return statusCodeResult.StatusCode == statusCode;
    }
}
