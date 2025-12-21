namespace InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

public interface ISortEnumTermTransformer<T>
{
    public IEnumerable<T> Transform(IEnumerable<T> values);
}
