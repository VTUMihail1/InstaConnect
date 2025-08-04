using System.Reflection;

using InstaConnect.Common.Tests.Utilities.Types.Enums.Transformers;
using InstaConnect.Common.Tests.Utilities.Types.Ints.Transformers;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class StringWithMessageDataAttribute : StringDataAttribute
{
    public string Message { get; }

    protected StringWithMessageDataAttribute(IStringTransformer transformer, string message) : base(transformer)
    {
        Message = message;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Transformer, Message };
    }
}
