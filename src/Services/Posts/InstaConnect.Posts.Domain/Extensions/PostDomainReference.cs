using System.Reflection;

namespace InstaConnect.Posts.Domain.Extensions;
public static class PostDomainReference
{
    public static readonly Assembly Assembly = typeof(PostDomainReference).Assembly;
}
