using System.Reflection;

namespace InstaConnect.Identity.Domain.Features.Common.Extensions;

public static class IdentityDomainReference
{
    public static readonly Assembly Assembly = typeof(IdentityDomainReference).Assembly;
}
