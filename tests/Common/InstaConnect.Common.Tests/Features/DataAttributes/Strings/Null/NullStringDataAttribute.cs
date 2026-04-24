using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.Null;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NullStringDataAttribute : StringDataAttribute
{
    protected NullStringDataAttribute() : base(new NullStringTransformer())
    {

    }
}
