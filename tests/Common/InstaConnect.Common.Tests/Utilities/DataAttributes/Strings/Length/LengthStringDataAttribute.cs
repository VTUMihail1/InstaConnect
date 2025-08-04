using System.Reflection;

using InstaConnect.Common.Tests.DataAttributes.Strings.Length;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Length;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Transformers;

using Xunit.Sdk;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class LengthStringDataAttribute : StringDataAttribute
{
    protected LengthStringDataAttribute(int length) : base(new LengthStringTransformer(length))
    {

    }
}
