using InstaConnect.Common.Tests.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Ints.TooLarge;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooLargeIntWithMessageDataAttribute : IntWithMessageDataAttribute
{
    protected TooLargeIntWithMessageDataAttribute(int maxValue) : base(
        new TooLargeIntTransformer(maxValue),
        new TooLargeIntMessageTransformer(maxValue))
    {
    }
}
