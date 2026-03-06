namespace InstaConnect.Common.Tests.DataAttributes.Base;

public interface ITransformer<TValue>
{
    public TValue Transform(TValue value);
}
