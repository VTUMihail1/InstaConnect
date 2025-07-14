using System.Reflection;

using InstaConnect.Posts.Presentation.Extensions;

namespace InstaConnect.Common.Tests.Extensions;
public static class CommonTestReference
{
    public static readonly Assembly Assembly = typeof(CommonDomainReference).Assembly;
}
