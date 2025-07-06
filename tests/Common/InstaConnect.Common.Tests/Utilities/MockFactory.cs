using System.Reflection;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;

using Mapster;

using MapsterMapper;

namespace InstaConnect.Common.Tests.Utilities;

public static class MockFactory
{
    public static CancellationToken CreateCancellationToken()
    {
        return new CancellationToken();
    }

    public static IApplicationSender CreateApplicationSender()
    {
        return Mocker.Mock<IApplicationSender>();
    }

    public static IApplicationMapper CreateApplicationMapper(Assembly assembly)
    {
        var config = new TypeAdapterConfig();
        config.Scan(assembly);

        return new ApplicationMapper(new Mapper(config));
    }
}
