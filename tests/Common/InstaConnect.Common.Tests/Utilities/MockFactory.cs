using System.Reflection;

using InstaConnect.Common.Domain.Helpers;

using Mapster;

using MapsterMapper;

using MassTransit;

using NSubstitute;

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

    public static ConsumeContext<TEvent> CreateConsumerContext<TEvent>(TEvent message, CancellationToken cancellationToken)
        where TEvent : class, IEventRequest
    {
        var consumeContext = Mocker.Mock<ConsumeContext<TEvent>>();

        consumeContext.Message.Returns(message);
        consumeContext.CancellationToken.Returns(cancellationToken);

        return consumeContext;
    }

    public static IApplicationMapper CreateApplicationMapper(Assembly assembly)
    {
        var config = new TypeAdapterConfig();
        config.Scan(assembly);

        return new ApplicationMapper(new Mapper(config));
    }
}
