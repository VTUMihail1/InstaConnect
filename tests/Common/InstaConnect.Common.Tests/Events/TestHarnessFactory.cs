using System.Reflection;

using InstaConnect.Common.Tests.Extensions;

using MassTransit.Testing;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Events;

public class TestHarnessFactory : ITestHarnessFactory
{
    private string _connectionString;
    private string _prefix;
    private Assembly[] _currentAssemblies;

    public TestHarnessFactory(string connectionString, string prefix, Assembly[] currentAssemblies)
    {
        _connectionString = connectionString;
        _prefix = prefix;
        _currentAssemblies = currentAssemblies;
    }

    public ITestHarness Create()
    {
        return new ServiceCollection()
                .AddMassTransitTestEventHarness(_connectionString, _prefix, _currentAssemblies)
                .BuildServiceProvider(true)
                .GetTestHarness();
    }
}

