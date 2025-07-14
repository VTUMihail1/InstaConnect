using System.Reflection;

using InstaConnect.Common.Tests.Utilities.Variants.Int;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Int.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class IntValueDataAttribute : DataAttribute
{
    public IntVariantType Type { get; set; }

    protected IntValueDataAttribute(IntVariantType type)
    {
        Type = type;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Type };
    }
}

