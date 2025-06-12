using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class OutOfBoundsMaxStringDataAttribute : DataAttribute
{
    public int Max => _max;

    private readonly int _max;

    protected OutOfBoundsMaxStringDataAttribute(int max)
    {
        _max = max;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { DataFaker.GetString(_max + 1) };
    }
}
