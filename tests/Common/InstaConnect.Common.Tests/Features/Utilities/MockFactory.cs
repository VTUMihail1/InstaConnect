using System.Reflection;

using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Helpers;

using Mapster;

using MapsterMapper;

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

	public static IApplicationMapper CreateMapper(params Assembly[] assemblies)
	{
		var config = new TypeAdapterConfig();
		config.Scan(assemblies);

		return new ApplicationMapper(new Mapper(config));
	}
}
