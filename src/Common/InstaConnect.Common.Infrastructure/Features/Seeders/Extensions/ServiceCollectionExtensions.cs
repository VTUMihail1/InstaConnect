using InstaConnect.Common.Infrastructure.Features.Seeders.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Infrastructure.Features.Seeders.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddSeeders<TDatabaseSeeder>()
			where TDatabaseSeeder : class, IDatabaseSeeder
		{
			serviceCollection.AddScoped<IDatabaseSeeder>(sp => sp.GetRequiredService<TDatabaseSeeder>());

			return serviceCollection;
		}
	}
}
