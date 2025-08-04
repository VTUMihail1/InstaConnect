using System.Linq.Expressions;

using AutoFixture;
using AutoFixture.Dsl;

using InstaConnect.Common.Tests.Utilities.DataAttributes.DateTimeOffsets.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.Utilities.Builders;

public class ObjectBuilder<T>
{
    private readonly ICustomizationComposer<T> _customizationComposer;

    public ObjectBuilder(ICustomizationComposer<T> customizationComposer)
    {
        _customizationComposer = customizationComposer;
    }

    public ObjectBuilder<T> With(Expression<Func<T, string?>> propertyPicker, string? value, IStringTransformer? transformer = null)
    {
        if (transformer != null)
        {
            value = transformer.Transform(value);
        }

        _customizationComposer.With(propertyPicker, value);

        return this;
    }

    public ObjectBuilder<T> With(Expression<Func<T, int>> propertyPicker, int value, IIntTransformer? transformer = null)
    {
        if (transformer != null)
        {
            value = transformer.Transform(value);
        }

        _customizationComposer.With(propertyPicker, value);

        return this;
    }

    public ObjectBuilder<T> With(Expression<Func<T, DateTimeOffset>> propertyPicker, DateTimeOffset value, IDateTimeOffsetTransformer? transformer = null)
    {
        if (transformer != null)
        {
            value = transformer.Transform(value);
        }

        _customizationComposer.With(propertyPicker, value);

        return this;
    }

    public ObjectBuilder<T> With<TEnum>(Expression<Func<T, TEnum>> propertyPicker, TEnum value, IEnumTransformer<TEnum>? transformer = null)
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

    public T Create()
    {
        return _customizationComposer.Create();
    }
}
