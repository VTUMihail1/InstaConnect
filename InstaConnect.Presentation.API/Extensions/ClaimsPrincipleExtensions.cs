using System.Security.Claims;

namespace InstaConnect.Presentation.API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetCurrentUserId(this ClaimsPrincipal principal) => principal.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
