using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InstaConnect.Shared.Presentation.Extensions;

internal static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(ClaimTypes.NameIdentifier)!;
    }

    public static string GetUserName(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(ClaimTypes.Name)!;
    }
}


