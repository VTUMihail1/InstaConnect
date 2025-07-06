using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class OutOfBoundsIntDataAttribute : DataAttribute
{
    public abstract int Value { get; }
    public abstract string Message { get; }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Value, Message };
    }
}
