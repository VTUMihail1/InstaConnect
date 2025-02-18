using System.Reflection;

namespace InstaConnect.Emails.Application.Extensions;
public static class ApplicationReference
{
    public static readonly Assembly Assembly = typeof(ApplicationReference).Assembly;
}
