using System.Reflection;

using InstaConnect.Common.Tests.Utilities.Types.Enums.Transformers;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class IntWithMessageDataAttribute : IntDataAttribute
{
    public string Message { get; }

    protected IntWithMessageDataAttribute(IIntTransformer transformer, string message) : base(transformer)
    {
        Message = message;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Transformer, Message };
    }
}
