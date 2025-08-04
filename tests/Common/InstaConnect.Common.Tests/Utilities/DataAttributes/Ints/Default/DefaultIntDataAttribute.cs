using System.Reflection;

using InstaConnect.Common.Tests.DataAttributes.Ints.Default;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Default;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultIntDataAttribute : IntDataAttribute
{
    protected DefaultIntDataAttribute() : base(new DefaultIntTransformer())
    {
    }
}  
