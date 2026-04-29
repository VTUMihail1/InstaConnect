using System.Reflection;
using System.Text;

using InstaConnect.Common.Domain.Features.Emails.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Tests.Features.Events;
using InstaConnect.Common.Tests.Features.Utilities;

using MassTransit;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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

			return serviceCollection;
		}

		public IServiceCollection AddTestJwtAuth()
		{
			serviceCollection
				.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MockValues.AccessTokenSecurityKey)),
						ValidateIssuer = true,
						ValidIssuer = MockValues.AccessTokenIssuer,
						ValidateAudience = true,
						ValidAudience = MockValues.AccessTokenAudience,
						ValidateLifetime = true,
					};
				});

			return serviceCollection;
		}
	}
}
