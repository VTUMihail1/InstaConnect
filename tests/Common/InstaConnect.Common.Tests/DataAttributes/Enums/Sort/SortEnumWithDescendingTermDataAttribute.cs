using System.Reflection;

namespace InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class SortEnumWithDescendingTermDataAttribute<TEnum, T, TValue> : SortEnumDataAttribute<TEnum>
    where TEnum : Enum
{
    public ISortEnumTermTransformer<T> TermTransformer { get; }

    protected SortEnumWithDescendingTermDataAttribute(TEnum value, Func<T, TValue> term)
        : base(value)
    {
        TermTransformer = new SortEnumDescendingTermTransformer<T, TValue>(term);
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Transformer, TermTransformer };
    }
}
