using MassTransit.Testing;

namespace InstaConnect.Common.Tests.Features.Events;

public interface ITestHarnessFactory
{
	public ITestHarness Create();
}
