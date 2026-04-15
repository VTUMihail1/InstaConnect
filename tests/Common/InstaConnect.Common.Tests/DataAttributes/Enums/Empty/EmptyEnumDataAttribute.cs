using InstaConnect.Common.Tests.DataAttributes.Enums.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Enums.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyEnumDataAttribute<TEnum> : EnumDataAttribute<TEnum>
    where TEnum : Enum
{
    protected EmptyEnumDataAttribute() : base(new EmptyEnumTransformer<TEnum>())
    {

    }
}

