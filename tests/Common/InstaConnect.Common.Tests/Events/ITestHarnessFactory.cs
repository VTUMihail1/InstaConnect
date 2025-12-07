using MassTransit.Testing;

namespace InstaConnect.Common.Tests.Events;
public interface ITestHarnessFactory
{
    ITestHarness Create();
}