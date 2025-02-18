using System.Reflection;

namespace InstaConnect.Posts.Infrastructure.Extensions;
public static class InfrastructureReference
{
    public static readonly Assembly Assembly = typeof(InfrastructureReference).Assembly;
}
