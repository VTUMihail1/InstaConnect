using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NullWithMessageDataAttribute : DataAttribute
{
    public string Message { get; }

    protected NullWithMessageDataAttribute(string message)
    {
        Message = message;
    }

    public override IEnumerable<object?[]> GetData(MethodInfo testMethod)
    {
        yield return new object?[] { null, Message };
    }
}


