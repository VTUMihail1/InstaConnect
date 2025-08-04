using System.Reflection;

using InstaConnect.Common.Tests.DataAttributes.Enums.Empty;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Utilities.Types.Enums.Empty;
using InstaConnect.Common.Tests.Utilities.Types.Enums.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyEnumDataAttribute<TEnum> : EnumDataAttribute<TEnum>
    where TEnum : Enum
{
    protected EmptyEnumDataAttribute() : base(new EmptyEnumTransformer<TEnum>())
    {
        
    }
}

