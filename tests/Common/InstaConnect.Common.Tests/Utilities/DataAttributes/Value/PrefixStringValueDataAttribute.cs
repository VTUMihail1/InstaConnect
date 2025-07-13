using System.Reflection;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PrefixStringValueDataAttribute : DataAttribute
{
    public string Value { get; }

    public PrefixStringValueDataAttribute(string value)
    {
        Value = value;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { DataFaker.GetPrefixString(Value) };
    }
}

