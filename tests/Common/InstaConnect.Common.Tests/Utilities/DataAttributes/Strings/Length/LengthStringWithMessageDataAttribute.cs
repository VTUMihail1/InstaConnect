using System.Reflection;

using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class LengthStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected LengthStringWithMessageDataAttribute(int value, string message) : base(new LengthStringTransformer(value), message)
    {
    }
}
