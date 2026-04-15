using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.TooShort;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TooShortStringDataAttribute : StringDataAttribute
{
    protected TooShortStringDataAttribute(int minLength) : base(new TooShortStringTransformer(minLength))
    {

    }
}
