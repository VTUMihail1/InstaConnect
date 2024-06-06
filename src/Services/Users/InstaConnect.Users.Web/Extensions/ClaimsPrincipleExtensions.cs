using System.Security.Claims;
using InstaConnect.Users.Web.Models.Requests.User;

namespace InstaConnect.Users.Web.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static UserRequestModel GetUserRequestModel(this ClaimsPrincipal principal) => new()
    {
        Id = principal.FindFirstValue(ClaimTypes.NameIdentifier)!
    };
}