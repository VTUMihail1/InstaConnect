using System.Reflection;

using InstaConnect.Common.Tests.DataAttributes.Strings.Null;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Null;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Null;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NullStringDataAttribute : StringDataAttribute
{
    protected NullStringDataAttribute() : base(new NullStringTransformer())
    {

    }
}
