using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.NotEqual;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NotEqualStringDataAttribute : StringDataAttribute
{
    protected NotEqualStringDataAttribute() : base(new NotEqualStringTransformer())
    {

    }
}
