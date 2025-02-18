using System.Reflection;

namespace InstaConnect.Follows.Domain.Extensions;
public static class DomainReference
{
    public static readonly Assembly Assembly = typeof(DomainReference).Assembly;
}
