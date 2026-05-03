using InstaConnect.Common.Infrastructure.Features.Seedings.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static partial class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddDatabaseSeeder<TDatabaseSeeder>()
			where TDatabaseSeeder : class, IDatabaseSeeder
		{
			serviceCollection.AddScoped<IDatabaseSeeder>(sp => sp.GetRequiredService<TDatabaseSeeder>());

			return serviceCollection;
		}
	}
}
