using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.Length;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class LengthStringDataAttribute : StringDataAttribute
{
    protected LengthStringDataAttribute(int length) : base(new LengthStringTransformer(length))
    {

    }
}
