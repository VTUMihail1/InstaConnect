using System.Reflection;

using InstaConnect.Common.Tests.DataAttributes.Ints.Empty;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Empty;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyIntDataAttribute : IntDataAttribute
{
    protected EmptyIntDataAttribute() : base(new EmptyIntTransformer())
    {
    }
}
