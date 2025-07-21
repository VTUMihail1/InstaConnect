using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Strings.Default;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DefaultStringDataAttribute : StringDataAttribute
{
    protected DefaultStringDataAttribute() : base(new DefaultStringTransformer())
    {

    }
}
