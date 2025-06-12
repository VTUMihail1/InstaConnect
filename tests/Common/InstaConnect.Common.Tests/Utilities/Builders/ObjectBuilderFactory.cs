namespace InstaConnect.Common.Tests.Utilities.Builders;

public static class ObjectBuilderFactory
{
    public static ObjectBuilder<T> Build<T>()
    {
        return new ObjectBuilder<T>();
    }
}
