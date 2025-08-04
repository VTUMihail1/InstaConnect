using System.Reflection;

using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Utilities.Types.Enums.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultEnumWithMessageDataAttribute<TEnum> : EnumWithMessageDataAttribute<TEnum>
    where TEnum : Enum
{
    protected DefaultEnumWithMessageDataAttribute(string message) : base(new DefaultEnumTransformer<TEnum>(), message)
    {

    }
}

