using System.Reflection;

using InstaConnect.Common.Tests.Utilities.Types.Enums.Base;
using InstaConnect.Common.Tests.Utilities.Types.Enums.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.Types.Enums.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyEnumWithMessageDataAttribute<TEnum> : EnumWithMessageDataAttribute<TEnum>
    where TEnum : Enum
{
    protected EmptyEnumWithMessageDataAttribute(string message) : base(new EmptyEnumTransformer<TEnum>(), message)
    {

    }
}

