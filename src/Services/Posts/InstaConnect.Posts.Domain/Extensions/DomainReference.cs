using System.Reflection;

namespace InstaConnect.Posts.Domain.Extensions;
public static class DomainReference
{
    public static readonly Assembly Assembly = typeof(DomainReference).Assembly;
}
