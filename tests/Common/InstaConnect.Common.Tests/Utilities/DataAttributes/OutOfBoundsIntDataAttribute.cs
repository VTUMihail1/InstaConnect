using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class OutOfBoundsIntDataAttribute : DataAttribute
{
    public int Value { get; }

    public string Message { get; }

    protected OutOfBoundsIntDataAttribute(int value, string message)
    {
        Value = value;
        Message = message;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Value, Message };
    }
}
