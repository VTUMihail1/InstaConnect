using System.Linq.Expressions;

using AutoFixture;
using AutoFixture.Dsl;

namespace InstaConnect.Common.Tests.Utilities.Builders;

public class ObjectBuilder<T>
{
    private readonly ICustomizationComposer<T> _composer;

    public ObjectBuilder()
    {
        var fixture = new Fixture();
        _composer = fixture.Build<T>();
    }

    public ObjectBuilder<T> With<TProperty>(Expression<Func<T, TProperty>> propertyPicker, TProperty value)
    {
        _composer.With(propertyPicker, value);

        return this;
    }

    public ObjectBuilder<T> Without<TProperty>(Expression<Func<T, TProperty>> propertyPicker)
    {
        _composer.Without(propertyPicker);

        return this;
    }

    public T Create()
    {
        return _composer.Create();
    }
}
