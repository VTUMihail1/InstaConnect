using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.String;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class OutOfBoundsStringWithMessageDataAttribute : DataAttribute
{
    public int Length { get; }

    public string Message { get; }

    protected OutOfBoundsStringWithMessageDataAttribute(int length, string message)
    {
        Length = length;
        Message = message;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { DataFaker.GetString(Length), Message };
    }
}
