using InstaConnect.Common.Tests.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Ints.Value;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class ValueIntDataAttribute : IntDataAttribute
{
    protected ValueIntDataAttribute(int value) : base(new ValueIntTransformer(value))
    {

    }
}
