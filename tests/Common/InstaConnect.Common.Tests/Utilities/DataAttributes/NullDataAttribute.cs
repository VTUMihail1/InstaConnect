using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NullDataAttribute : DataAttribute
{
    public override IEnumerable<object?[]> GetData(MethodInfo testMethod)
    {
        yield return new object?[] { null };
    }
}


