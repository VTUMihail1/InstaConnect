using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.String;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class OutOfBoundsStringDataAttribute : DataAttribute
{
    public int Length { get; }

    protected OutOfBoundsStringDataAttribute(int length)
    {
        Length = length;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { DataFaker.GetString(Length)};
    }
}
