using System.Reflection;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EnumWithMessageDataAttribute<TEnum> : EnumDataAttribute<TEnum>
    where TEnum : Enum
{
    public string Message { get; }

    protected EnumWithMessageDataAttribute(IEnumTransformer<TEnum> transformer, string message) : base(transformer)
    {
        Message = message;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Transformer, Message };
    }
}
