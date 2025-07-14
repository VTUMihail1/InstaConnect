using System.Reflection;

using InstaConnect.Common.Tests.Utilities.Variants.String;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.String.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class StringValueDataAttribute : DataAttribute
{
    public StringVariantType Type { get; set; }

    protected StringValueDataAttribute(StringVariantType type)
    {
        Type = type;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Type };
    }
}

