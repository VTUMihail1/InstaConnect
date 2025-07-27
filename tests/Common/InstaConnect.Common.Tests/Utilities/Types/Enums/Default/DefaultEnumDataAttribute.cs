using InstaConnect.Common.Tests.Utilities.Types.Enums.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Enums.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultEnumDataAttribute<TEnum> : EnumDataAttribute<TEnum>
    where TEnum : Enum
{
    protected DefaultEnumDataAttribute() : base(new DefaultEnumTransformer<TEnum>())
    {
    }
}
