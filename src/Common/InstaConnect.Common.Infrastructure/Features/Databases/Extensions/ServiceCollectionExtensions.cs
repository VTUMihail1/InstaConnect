using InstaConnect.Common.Application.Features.Databases.Abstractions;
using InstaConnect.Common.Domain.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Common.Extensions;
using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers.Conventions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers.SortOrders;
using InstaConnect.Common.Infrastructure.Features.Databases.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddDatabases<TContext>(IConfiguration configuration)
			where TContext : class, IMongoDbContext
		{
			const string ConventionName = "ApplicationConventionPack";

			serviceCollection.AddValidatedOptions<MongoOptions>(MongoOptions.SectionName);
			var options = configuration.GetOptions<MongoOptions>(MongoOptions.SectionName);

			serviceCollection.AddSingleton<IMongoClient>(_ =>
				new MongoClient(options.ConnectionString));

			serviceCollection.AddSingleton(sp =>
				sp.GetRequiredService<IMongoClient>()
				  .GetDatabase(options.Name));

			serviceCollection
				.AddScoped<IPaginator, Paginator>()
				.AddScoped<IUnitOfWork, UnitOfWork>();

			serviceCollection.AddScoped<IMongoDbContext>(sp => sp.GetRequiredService<TContext>());

			var conventionPack = new ConventionPack
			{
				new SnakeCaseElementNameConvention(),
				new IgnoreExtraElementsConvention(true)
			};

			ConventionRegistry.Register(ConventionName, conventionPack, t => true);

			serviceCollection.AddHealthChecks()
				 .AddMongoDb(sp => sp.GetRequiredService<IMongoClient>(),
							 _ => options.Name);

			return serviceCollection;
		}

		public IServiceCollection AddDatabaseSortOrders()
		{
			serviceCollection.AddScoped<ISortOrdererFactory, SortOrdererFactory>()
							 .AddImplementationsOf<ISortOrderer>(CommonInfrastructureReference.Assembly);

			return serviceCollection;
		}
	}
}
