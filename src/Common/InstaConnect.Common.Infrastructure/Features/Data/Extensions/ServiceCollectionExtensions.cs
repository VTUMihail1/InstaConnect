using InstaConnect.Common.Application.Features.Data.Abstractions;
using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Common.Extensions;
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Data.Helpers;
using InstaConnect.Common.Infrastructure.Features.Data.Helpers.Conventions;
using InstaConnect.Common.Infrastructure.Features.Data.Helpers.SortOrders;
using InstaConnect.Common.Infrastructure.Features.Data.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddUnitOfWork()
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            return serviceCollection;
        }

        public IServiceCollection AddMongo(IConfiguration configuration)
        {
            const string ConventionName = "ApplicationConventionPack";

            serviceCollection.AddValidatedOptions<MongoOptions>(MongoOptions.SectionName);
            var options = configuration.GetOptions<MongoOptions>(MongoOptions.SectionName);

            serviceCollection.AddSingleton<IMongoClient>(_ =>
                new MongoClient(options.ConnectionString));

            serviceCollection.AddSingleton(sp =>
                sp.GetRequiredService<IMongoClient>()
                  .GetDatabase(options.Name));

            serviceCollection.AddScoped<IPaginator, Paginator>()
                             .AddScoped<IMongoDbContext, MongoDbContext>();

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

        public IServiceCollection AddSortOrders()
        {
            serviceCollection.AddScoped<ISortOrdererFactory, SortOrdererFactory>()
                             .AddImplementationsOf<ISortOrderer>(CommonInfrastructureReference.Assembly);

            return serviceCollection;
        }
    }
}
