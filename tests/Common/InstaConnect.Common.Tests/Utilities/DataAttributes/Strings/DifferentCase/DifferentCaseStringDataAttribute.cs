using InstaConnect.Common.Tests.DataAttributes.Strings.DifferentCase;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Strings.DifferentCase;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.DifferentCase;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DifferentCaseStringDataAttribute : StringDataAttribute
{
    protected DifferentCaseStringDataAttribute() : base(new DifferentCaseStringTransformer())
    {

    }
}
