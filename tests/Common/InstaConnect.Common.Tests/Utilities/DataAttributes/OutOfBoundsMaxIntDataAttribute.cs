using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class OutOfBoundsMaxIntDataAttribute : DataAttribute
{
    public int Max => _max;

    private readonly int _max;

    protected OutOfBoundsMaxIntDataAttribute(int max)
    {
        _max = max;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { _max + 1 };
    }
}
