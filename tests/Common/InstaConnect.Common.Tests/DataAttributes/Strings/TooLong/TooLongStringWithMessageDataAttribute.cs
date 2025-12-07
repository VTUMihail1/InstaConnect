using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.TooLong;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooLongStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
    protected TooLongStringWithMessageDataAttribute(int maxValue)
        : base(new TooLongStringTransformer(maxValue),
               new TooLongStringMessageTransformer(maxValue))
    {
    }
}
