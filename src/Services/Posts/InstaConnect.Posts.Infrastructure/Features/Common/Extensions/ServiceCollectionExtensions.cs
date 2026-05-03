using System.Reflection;

using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Common.Utilities;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddInfrastructure(
			IConfiguration configuration,
			IWebHostEnvironment webHostEnvironment,
			Assembly presentationAssembly)
		{
			serviceCollection
				.AddUserServices()
				.AddPostServices()
				.AddPostLikeServices()
				.AddPostCommentServices()
				.AddPostCommentLikeServices();

			serviceCollection
				.AddOpenTelemetry(configuration, webHostEnvironment)
				.AddMapper(PostsInfrastructureReference.Assembly)
				.AddServicesWithMatchingInterfaces(PostsInfrastructureReference.Assembly)
				.AddMongo<IPostsContext>(configuration)
				.AddRabbitMQ(configuration, PostsEventHandlerUtilities.Prefix, presentationAssembly)
				.AddJwtBearer(configuration)
				.AddGuidProvider()
				.AddDateTimeProvider()
				.AddSortOrders();

			return serviceCollection;
		}
	}
}
