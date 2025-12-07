using InstaConnect.Common.Tests.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Ints.TooSmall;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooSmallValueIntDataAttribute : IntDataAttribute
{
    protected TooSmallValueIntDataAttribute(int minValue) : base(new TooSmallIntTransformer(minValue))
    {

    }
}
