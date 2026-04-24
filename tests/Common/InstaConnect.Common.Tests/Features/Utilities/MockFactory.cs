using System.Reflection;

using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Helpers;
using InstaConnect.Common.Events.Features.Common.Abstractions;

using Mapster;

using MapsterMapper;

using MassTransit;

using NSubstitute;

namespace InstaConnect.Common.Tests.Features.Utilities;

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

    public static IApplicationMapper CreateMapper(params Assembly[] assemblies)
    {
        var config = new TypeAdapterConfig();
        config.Scan(assemblies);

        return new ApplicationMapper(new Mapper(config));
    }
}
