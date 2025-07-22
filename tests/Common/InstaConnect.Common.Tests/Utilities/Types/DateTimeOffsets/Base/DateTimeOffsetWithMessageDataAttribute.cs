using System.Reflection;

namespace InstaConnect.Common.Tests.Utilities.Types.DateTimes.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DateTimeOffsetWithMessageDataAttribute : DateTimeOffsetDataAttribute
{
    public string Message { get; }

    protected DateTimeOffsetWithMessageDataAttribute(IDateTimeOffsetTransformer transformer, string message)
        : base(transformer)
    {
        Message = message;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Transformer, Message };
    }
}
