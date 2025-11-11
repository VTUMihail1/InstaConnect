using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Common.Tests.DataAttributes.Base;

public static class TransformExtensions
{
    public static TValue TryTransform<TValue>(this ITransformer<TValue>? transformer, TValue value)
    {
        if (transformer.IsNotNull())
        {
            return transformer!.Transform(value);
        }

        return value;
    }
}
