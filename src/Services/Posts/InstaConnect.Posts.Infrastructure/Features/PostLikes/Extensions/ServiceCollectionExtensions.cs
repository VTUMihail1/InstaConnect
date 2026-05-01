using InstaConnect.Posts.Infrastructure.Features.Common.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostLikeServices()
		{
			serviceCollection.AddImplementationsOf<IPostLikesSortTermer>(PostsInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IPostLikesForUserSortTermer>(PostsInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IPostLikeIncluder>(PostsInfrastructureReference.Assembly);

			BsonClassMap.TryRegisterClassMap<PostLike>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.User);
				cm.MapMemberWithoutSerialization(c => c.Post);

				cm.MapCreator(c => new PostLike(
					c.Id,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
