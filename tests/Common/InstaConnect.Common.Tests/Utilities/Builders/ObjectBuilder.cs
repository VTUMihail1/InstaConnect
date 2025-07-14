using System.Linq.Expressions;

using AutoFixture;
using AutoFixture.Dsl;

using InstaConnect.Common.Tests.Utilities.Variants.Int;
using InstaConnect.Common.Tests.Utilities.Variants.String;

namespace InstaConnect.Common.Tests.Utilities.Builders;

public class ObjectBuilder<T>
{
    private readonly ICustomizationComposer<T> _composer;
    private readonly IntVariantProviderFactory _intVariantProviderFactory;
    private readonly StringVariantProviderFactory _stringVariantProviderFactory;

    public ObjectBuilder()
    {
        var fixture = new Fixture();
        _composer = fixture.Build<T>();
        _intVariantProviderFactory = new();
        _stringVariantProviderFactory = new();
    }

    public ObjectBuilder<T> With(Expression<Func<T, string?>> propertyPicker, string? value, StringVariantType type)
    {
        var provider = _stringVariantProviderFactory.Create(variant);
        _composer.With(propertyPicker, provider.GetVariant(value));

        return this;
    }

    public ObjectBuilder<T> With(Expression<Func<T, int>> propertyPicker, int value, IntVariantType variant)
    {
        var provider = _intVariantProviderFactory.Create(variant);
        _composer.With(propertyPicker, provider.GetVariant(value));

        return this;
    }

    public ObjectBuilder<T> With<TValue>(Expression<Func<T, TValue>> propertyPicker, TValue value)
    {
        _composer.With(propertyPicker, value);

        return this;
    }

    public ObjectBuilder<T> Without<TValue>(Expression<Func<T, TValue>> propertyPicker)
    {
        _composer.Without(propertyPicker);

        return this;
    }

    public T Create()
    {
        return _composer.Create();
    }
}
