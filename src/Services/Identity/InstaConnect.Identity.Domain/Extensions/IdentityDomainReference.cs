using System.Reflection;

namespace InstaConnect.Identity.Domain.Extensions;

public static class IdentityDomainReference
{
    public static readonly Assembly Assembly = typeof(IdentityDomainReference).Assembly;
}
