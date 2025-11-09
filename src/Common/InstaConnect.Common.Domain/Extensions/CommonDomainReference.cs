using System.Reflection;

namespace InstaConnect.Common.Domain.Extensions;
public static class CommonDomainReference
{
    public static readonly Assembly Assembly = typeof(CommonDomainReference).Assembly;
}
