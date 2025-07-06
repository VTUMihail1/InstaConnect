using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class OutOfBoundsStringDataAttribute : DataAttribute
{
    public abstract int Length { get; }
    public abstract string Message { get; }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { DataFaker.GetString(Length), Message };
    }
}
