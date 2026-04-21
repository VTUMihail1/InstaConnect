using System.Reflection;

namespace InstaConnect.Posts.Domain.Extensions;

public static class PostsDomainReference
{
    public static readonly Assembly Assembly = typeof(PostsDomainReference).Assembly;
}
