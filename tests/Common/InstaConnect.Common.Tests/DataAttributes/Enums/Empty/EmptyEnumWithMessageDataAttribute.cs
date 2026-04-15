using InstaConnect.Common.Tests.DataAttributes.Enums.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Enums.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyEnumWithMessageDataAttribute<TEnum> : EnumWithMessageDataAttribute<TEnum>
    where TEnum : Enum
{
    protected EmptyEnumWithMessageDataAttribute() : base(
        new EmptyEnumTransformer<TEnum>(),
        new EmptyEnumMessageTransformer<TEnum>())
    {

    }
}

