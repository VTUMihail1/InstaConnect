using System.Reflection;

using InstaConnect.Common.Tests.Utilities.Types.Ints.Base;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.Types.Ints.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyIntWithMessageDataAttribute : IntWithMessageDataAttribute
{
    protected EmptyIntWithMessageDataAttribute(string message) : base(new EmptyIntTransformer(), message)
    {
    }
}
