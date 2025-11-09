using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.Prefix;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class PrefixStringDataAttribute : StringDataAttribute
{
    protected PrefixStringDataAttribute() : base(new PrefixStringTransformer())
    {

    }
}
