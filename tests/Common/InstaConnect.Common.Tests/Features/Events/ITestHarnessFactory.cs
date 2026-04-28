using MassTransit.Testing;

namespace InstaConnect.Common.Tests.Features.Events;

public interface ITestHarnessFactory
{
    ITestHarness Create();
}
