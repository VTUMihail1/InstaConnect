using System.Reflection;

using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Null;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NullStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected NullStringWithMessageDataAttribute(string message) : base(new NullStringTransformer(), message)
    {
    }
}
