using InstaConnect.Common.Tests.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Ints.TooLarge;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooLargeIntDataAttribute : IntDataAttribute
{
    protected TooLargeIntDataAttribute(int maxValue) : base(new TooLargeIntTransformer(maxValue))
    {

    }
}
