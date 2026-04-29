namespace InstaConnect.Common.Tests.Features.DataAttributes.Base;

public static class TransformExtensions
{
	extension<TValue>(ITransformer<TValue>? transformer)
	{
		public TValue TryTransform(TValue value)
		{
			if (transformer != null)
			{
				return transformer.Transform(value);
			}

			return value;
		}
	}
}
