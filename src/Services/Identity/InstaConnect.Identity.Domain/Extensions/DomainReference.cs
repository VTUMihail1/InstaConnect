using System.Reflection;

namespace InstaConnect.Identity.Domain.Extensions;
public static class DomainReference
{
    public static readonly Assembly Assembly = typeof(DomainReference).Assembly;
}
