using InstaConnect.Common.Tests.DataAttributes.Enums.Default;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Utilities.Types.Enums.Default;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultEnumDataAttribute<TEnum> : EnumDataAttribute<TEnum>
    where TEnum : Enum
{
    protected DefaultEnumDataAttribute() : base(new DefaultEnumTransformer<TEnum>())
    {
    }
}
