using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Enums;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyEnumWithMessageDataAttribute<TEnum> : DataAttribute
    where TEnum : Enum
{
    public TEnum Value { get; set; }

    public string Message { get; }

    protected EmptyEnumWithMessageDataAttribute(TEnum value, string message)
    {
        Value = value;
        Message = message;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Value, Message };
    }
}
