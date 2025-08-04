using System.Reflection;

using InstaConnect.Common.Tests.DataAttributes.Ints.Value;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Value;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class ValueIntDataAttribute : IntDataAttribute
{
    protected ValueIntDataAttribute(int value) : base(new ValueIntTransformer(value))
    {

    }
}
