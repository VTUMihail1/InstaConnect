namespace InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

internal class SortEnumAscendingTermTransformer<T, TValue> : ISortEnumTermTransformer<T>
{
    private readonly Func<T, TValue> _term;

    public SortEnumAscendingTermTransformer(Func<T, TValue> term)
    {
        _term = term;
    }

    public IEnumerable<T> Transform(IEnumerable<T> values)
    {
        return values.OrderBy(_term).AsEnumerable();
    }
}
