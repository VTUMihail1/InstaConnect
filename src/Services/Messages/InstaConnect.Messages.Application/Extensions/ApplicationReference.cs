using System.Reflection;

namespace InstaConnect.Messages.Application.Extensions;
public static class ApplicationReference
{
    public static readonly Assembly Assembly = typeof(ApplicationReference).Assembly;
}
