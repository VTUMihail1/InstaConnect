using AutoFixture;

namespace InstaConnect.Common.Tests.Utilities.Builders;

public class ObjectBuilderFactory<T>
{
    private readonly Fixture _fixture;

    public ObjectBuilderFactory()
    {
        _fixture = new Fixture();
    }

    public ObjectBuilder<T> Create()
    {
        var customizationComposer = _fixture.Build<T>();
        var objectBuilder = new ObjectBuilder<T>(customizationComposer);

        return objectBuilder;
    }
}
