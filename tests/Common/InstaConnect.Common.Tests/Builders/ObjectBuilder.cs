using System.Linq.Expressions;

using AutoFixture;
using AutoFixture.Dsl;

using InstaConnect.Common.Tests.DataAttributes.DateTimeOffsets.Base;
using InstaConnect.Common.Tests.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.DataAttributes.Ints.Base;
using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.Builders;

public class ObjectBuilder<T>
{
    private readonly ICustomizationComposer<T> _customizationComposer;

    public ObjectBuilder(ICustomizationComposer<T> customizationComposer)
    {
        _customizationComposer = customizationComposer;
    }

    public ObjectBuilder<T> WithString(Expression<Func<T, string?>> propertyPicker, string? value, IStringTransformer? transformer = null)
    {
        if (transformer != null)
        {
            value = transformer.Transform(value);
        }

        _customizationComposer.With(propertyPicker, value);

        return this;
    }

    public ObjectBuilder<T> WithInt(Expression<Func<T, int>> propertyPicker, int value, IIntTransformer? transformer = null)
    {
        if (transformer != null)
        {
            value = transformer.Transform(value);
        }

        _customizationComposer.With(propertyPicker, value);

        return this;
    }

    public ObjectBuilder<T> WithDateTimeOffset(Expression<Func<T, DateTimeOffset>> propertyPicker, DateTimeOffset value, IDateTimeOffsetTransformer? transformer = null)
    {
        if (transformer != null)
        {
            value = transformer.Transform(value);
        }

        _customizationComposer.With(propertyPicker, value);

        return this;
    }

    public ObjectBuilder<T> WithEnum<TEnum>(Expression<Func<T, TEnum>> propertyPicker, TEnum value, IEnumTransformer<TEnum>? transformer = null)
        where TEnum : Enum
    {
        if (transformer != null)
        {
            value = transformer.Transform(value);
        }

        _customizationComposer.With(propertyPicker, value);

        return this;
    }

    public ObjectBuilder<T> With<TValue>(Expression<Func<T, TValue>> propertyPicker, TValue value)
    {
        _customizationComposer.With(propertyPicker, value);

        return this;
    }

    public ObjectBuilder<T> Without<TValue>(Expression<Func<T, TValue>> propertyPicker)
    {
        _customizationComposer.Without(propertyPicker);

        return this;
    }

    public T Build()
    {
        return _customizationComposer.Create();
    }
}
