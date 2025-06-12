using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class OutOfBoundsMinStringDataAttribute : DataAttribute
{
    public int Min => _min;

    private readonly int _min;

    protected OutOfBoundsMinStringDataAttribute(int min)
    {
        _min = min;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { DataFaker.GetString(_min - 1) };
    }
}
