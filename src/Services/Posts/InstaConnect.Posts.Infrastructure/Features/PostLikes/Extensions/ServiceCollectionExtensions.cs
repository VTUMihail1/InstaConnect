using InstaConnect.Common.Extensions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostLikeServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostLikeSortProperty>(PostInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IPostLikeIncludeProperty>(PostInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<PostLike>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => new { c.Id, c.UserId })
              .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.UnmapMember(c => c.User);
        });

        return serviceCollection;
    }
}
