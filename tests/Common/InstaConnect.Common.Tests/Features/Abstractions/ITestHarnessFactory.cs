using MassTransit.Testing;

namespace InstaConnect.Common.Tests.Features.Abstractions;

public interface ITestHarnessFactory
{
	public ITestHarness Create();
}
