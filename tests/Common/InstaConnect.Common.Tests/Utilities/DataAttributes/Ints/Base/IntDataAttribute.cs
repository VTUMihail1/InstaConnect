using System.Reflection;

using InstaConnect.Common.Tests.Utilities.Types.Enums.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class IntDataAttribute : DataAttribute
{
    public IIntTransformer Transformer { get; }

    protected IntDataAttribute(IIntTransformer transformer)
    {
        Transformer = transformer;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Transformer };
    }
}
