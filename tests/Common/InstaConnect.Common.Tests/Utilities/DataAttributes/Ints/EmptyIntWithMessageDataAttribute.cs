using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Int;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyIntWithMessageDataAttribute : DataAttribute
{
    public string Message { get; }

    protected EmptyIntWithMessageDataAttribute(string message)
    {
        Message = message;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { default(int), Message };
    }
}


