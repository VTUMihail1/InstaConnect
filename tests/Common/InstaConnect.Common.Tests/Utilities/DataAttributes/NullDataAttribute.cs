using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NullDataAttribute : DataAttribute
{
    public string Message { get; }

    protected NullDataAttribute(string message)
    {
        Message = message;
    }

    public override IEnumerable<object?[]> GetData(MethodInfo testMethod)
    {
        yield return new object?[] { null, Message };
    }
}

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NullValueDataAttribute : DataAttribute
{
    public override IEnumerable<object?[]> GetData(MethodInfo testMethod)
    {
        yield return new object?[] { null };
    }
}


