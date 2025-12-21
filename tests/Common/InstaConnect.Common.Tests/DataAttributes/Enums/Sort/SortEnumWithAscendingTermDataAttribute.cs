using System.Reflection;

namespace InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class SortEnumWithAscendingTermDataAttribute<TEnum, T, TValue> : SortEnumDataAttribute<TEnum>
    where TEnum : Enum
{
    public ISortEnumTermTransformer<T> TermTransformer { get; }

    protected SortEnumWithAscendingTermDataAttribute(TEnum value, Func<T, TValue> term)
        : base(value)
    {
        TermTransformer = new SortEnumAscendingTermTransformer<T, TValue>(term);
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { Transformer, TermTransformer };
    }
}
