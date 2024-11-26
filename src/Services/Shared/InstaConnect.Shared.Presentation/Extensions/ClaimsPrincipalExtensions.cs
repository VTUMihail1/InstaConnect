using System.Security.Claims;

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
