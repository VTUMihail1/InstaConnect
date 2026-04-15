using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.TooLong;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooLongStringDataAttribute : StringDataAttribute
{
    protected TooLongStringDataAttribute(int maxLength) : base(new TooLongStringTransformer(maxLength))
    {

    }
}
