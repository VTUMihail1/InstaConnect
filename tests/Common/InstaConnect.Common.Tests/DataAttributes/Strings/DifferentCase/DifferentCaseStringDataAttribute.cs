using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.DifferentCase;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DifferentCaseStringDataAttribute : StringDataAttribute
{
    protected DifferentCaseStringDataAttribute() : base(new DifferentCaseStringTransformer())
    {

    }
}
