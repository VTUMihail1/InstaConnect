using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

namespace InstaConnect.Common.Tests.Utilities.Types.Strings.DifferentCase;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DifferentCaseStringDataAttribute : StringDataAttribute
{
    protected DifferentCaseStringDataAttribute() : base(new DifferentCaseStringTransformer())
    {

    }
}
