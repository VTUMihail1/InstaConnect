using System.Reflection;

using InstaConnect.Common.Tests.Utilities.Types.Ints.Base;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.Types.Ints.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultIntDataAttribute : IntDataAttribute
{
    protected DefaultIntDataAttribute() : base(new DefaultIntTransformer())
    {
    }
}  
