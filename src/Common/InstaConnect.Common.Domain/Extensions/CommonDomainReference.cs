using System.Reflection;

namespace InstaConnect.Posts.Presentation.Extensions;
public static class CommonDomainReference
{
    public static readonly Assembly Assembly = typeof(CommonDomainReference).Assembly;
}
