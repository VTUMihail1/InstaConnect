using System.Reflection;

using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.Types.Strings.Length;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class LengthStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected LengthStringWithMessageDataAttribute(int value, string message) : base(new LengthStringTransformer(value), message)
    {
    }
}
