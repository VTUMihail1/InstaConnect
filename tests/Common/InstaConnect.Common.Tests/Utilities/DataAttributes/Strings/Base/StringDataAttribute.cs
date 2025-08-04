using System.Reflection;

using InstaConnect.Common.Tests.Utilities.Types.Enums.Transformers;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class StringDataAttribute : DataAttribute
{
    public IStringTransformer Transformer { get; }

    protected StringDataAttribute(IStringTransformer transformer)
    {
        Transformer = transformer;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Transformer };
    }
}
