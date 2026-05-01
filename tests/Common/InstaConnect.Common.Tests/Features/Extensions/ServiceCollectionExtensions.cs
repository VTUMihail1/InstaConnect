using System.Reflection;

using InstaConnect.Common.Domain.Features.Emails.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Tests.Features.Events;
using InstaConnect.Common.Tests.Features.Utilities;

using MassTransit;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Features.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddTestEventHarness(string connectionString, params Assembly[] currentAssemblies)
		{
			serviceCollection.AddMassTransitTestEventHarness(connectionString, currentAssemblies);

			serviceCollection.AddScoped<ITestHarnessFactory>(_ => new TestHarnessFactory(connectionString, currentAssemblies));
			serviceCollection.AddScoped<IEventHarness, EventHarness>();

			return serviceCollection;
		}

		public IServiceCollection AddMockImageHandler()
		{
			serviceCollection.AddScoped(_ => Mocker.Mock<IImageHandler>());

			return serviceCollection;
		}

		public IServiceCollection AddMockEmailSender()
		{
			serviceCollection.AddScoped(_ => Mocker.Mock<IEmailSender>());

			return serviceCollection;
		}

		internal IServiceCollection AddMassTransitTestEventHarness(string connectionString, params Assembly[] currentAssemblies)
		{
			serviceCollection.AddMassTransitTestHarness(busConfigurator =>
			{
				busConfigurator.SetKebabCaseEndpointNameFormatter();

				busConfigurator.AddConsumers(currentAssemblies);

				busConfigurator.UsingRabbitMq((context, configurator) =>
				{
					configurator.Host(connectionString);

					configurator.ConfigureEndpoints(context);
				});
			});

			serviceCollection.AddOptions<MassTransitHostOptions>().Configure(options =>
			{
				options.WaitUntilStarted = true;
				options.StartTimeout = TimeSpan.FromSeconds(10);
				options.StopTimeout = TimeSpan.FromSeconds(30);
				options.ConsumerStopTimeout = TimeSpan.FromSeconds(10);
			});

			return serviceCollection;
		}
	}
}
