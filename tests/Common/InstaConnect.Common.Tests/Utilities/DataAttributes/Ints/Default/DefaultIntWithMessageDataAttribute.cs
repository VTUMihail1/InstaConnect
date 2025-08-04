using System.Reflection;

using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultIntWithMessageDataAttribute : IntWithMessageDataAttribute
{
    protected DefaultIntWithMessageDataAttribute(string message) : base(new DefaultIntTransformer(), message)
    {
    }
}
