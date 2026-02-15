namespace InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

public interface ISortEnumTermTransformer<T>
    where T : IEntity
{
    public IEnumerable<T> Transform(IEnumerable<T> values);
}
