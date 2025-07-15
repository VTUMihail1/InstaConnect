using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Enums;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyEnumDataAttribute<TEnum> : DataAttribute
    where TEnum : Enum
{
    public TEnum Value { get; set; }

    protected EmptyEnumDataAttribute(TEnum value)
    {
        Value = value;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Value };
    }
}
