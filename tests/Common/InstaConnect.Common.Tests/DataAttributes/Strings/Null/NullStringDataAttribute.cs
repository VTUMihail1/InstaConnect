using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.Null;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NullStringDataAttribute : StringDataAttribute
{
    protected NullStringDataAttribute() : base(new NullStringTransformer())
    {

    }
}
