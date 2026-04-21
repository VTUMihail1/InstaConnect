using System.Reflection;

using InstaConnect.Common.Tests.Extensions;

using MassTransit;
using MassTransit.Testing;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Events;

public class TestHarnessFactory : ITestHarnessFactory
{
    private readonly string _connectionString;
    private readonly Assembly _currentAssembly;
    private readonly Action<IRabbitMqBusFactoryConfigurator, IBusRegistrationContext>? _configureEndpoints;

    public TestHarnessFactory(string connectionString, Assembly currentAssembly, Action<IRabbitMqBusFactoryConfigurator, IBusRegistrationContext>? configureEndpoints = null)
    {
        _connectionString = connectionString;
        _currentAssembly = currentAssembly;
        _configureEndpoints = configureEndpoints;
    }

    public ITestHarness Create()
    {
        return new ServiceCollection()
                .AddMassTransitTestEventHarness(_connectionString, _currentAssembly, _configureEndpoints)
                .BuildServiceProvider(true)
                .GetTestHarness();
    }
}

