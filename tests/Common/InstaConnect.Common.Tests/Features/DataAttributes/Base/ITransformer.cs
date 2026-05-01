namespace InstaConnect.Common.Tests.Features.DataAttributes.Base;

public interface ITransformer<TValue>
{
	public TValue Transform(TValue value);
}
