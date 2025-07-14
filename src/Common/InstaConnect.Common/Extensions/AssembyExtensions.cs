using System.Reflection;

namespace InstaConnect.Common.Extensions;

public static class AssembyExtensions
{
    public static IEnumerable<T> AddImplementationOf<T>(this Assembly assembly)
    {
        return assembly
            .GetTypes()
            .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Select(t => (T)Activator.CreateInstance(t)!);
    }
}
