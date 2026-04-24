using System.Reflection;

using InstaConnect.Common.Tests.Features.Extensions;

using MassTransit.Testing;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Features.Events;

public class TestHarnessFactory : ITestHarnessFactory
{
    private string _connectionString;
    private Assembly[] _currentAssemblies;

    public TestHarnessFactory(string connectionString, Assembly[] currentAssemblies)
    {
        _connectionString = connectionString;
        _currentAssemblies = currentAssemblies;
    }

    public ITestHarness Create()
    {
        return new ServiceCollection()
                .AddMassTransitTestEventHarness(_connectionString, _currentAssemblies)
                .BuildServiceProvider(true)
                .GetTestHarness();
    }
}

