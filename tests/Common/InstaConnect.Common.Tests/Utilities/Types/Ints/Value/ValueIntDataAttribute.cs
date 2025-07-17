using System.Reflection;

using InstaConnect.Common.Tests.Utilities.Types.Ints.Base;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.Types.Ints.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class ValueIntDataAttribute : IntDataAttribute
{
    protected ValueIntDataAttribute(int value) : base(new ValueIntTransformer(value))
    {

    }
}
