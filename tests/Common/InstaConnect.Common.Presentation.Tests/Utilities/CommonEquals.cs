using InstaConnect.Common.Presentation.Models;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.Tests.Utilities;
public static class CommonEquals
{
    public static bool Matches(
        this ApplicationProblemDetails d,
        int statusCode,
        string detail)
    {
        return d.Status == statusCode &&
               d.Detail == detail;
    }

    public static bool Matches(
        this ApplicationProblemDetails d,
        int statusCode,
        string detail,
        string errorMessage)
    {
        return d.Status == statusCode &&
               d.Detail == detail &&
               d.Errors!.All(e => e == errorMessage);
    }

    public static bool Matches(
        this ObjectResult s,
        int statusCode)
    {
        return s.StatusCode == statusCode;
    }

    public static bool Matches(
        this StatusCodeResult s,
        int statusCode)
    {
        return s.StatusCode == statusCode;
    }
}
