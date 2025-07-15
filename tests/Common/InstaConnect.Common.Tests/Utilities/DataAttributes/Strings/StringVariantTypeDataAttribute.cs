using System.Reflection;

using InstaConnect.Common.Tests.Utilities.Variants.String;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.String;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class StringVariantTypeDataAttribute : DataAttribute
{
    public StringVariantType Type { get; set; }

    protected StringVariantTypeDataAttribute(StringVariantType type)
    {
        Type = type;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Type };
    }
}

