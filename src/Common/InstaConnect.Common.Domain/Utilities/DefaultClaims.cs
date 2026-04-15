using System.Security.Claims;

namespace InstaConnect.Common.Domain.Utilities;

public static class DefaultClaims
{
    public const string Id = ClaimTypes.NameIdentifier;

    public const string Email = ClaimTypes.Email;

    public const string FirstName = ClaimTypes.GivenName;

    public const string LastName = ClaimTypes.Surname;

    public const string Name = ClaimTypes.Name;
}
