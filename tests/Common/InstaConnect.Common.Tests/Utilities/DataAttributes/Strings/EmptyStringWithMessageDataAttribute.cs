using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.String;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyStringWithMessageDataAttribute : DataAttribute
{
    public string Message { get; }

    protected EmptyStringWithMessageDataAttribute(string message)
    {
        Message = message;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { string.Empty, Message };
    }
}
