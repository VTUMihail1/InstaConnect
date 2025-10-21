using InstaConnect.Common.Extensions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostCommentServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostCommentSortProperty>(PostInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IPostCommentIncludeProperty>(PostInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<PostComment>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => new { c.Id, c.CommentId })
              .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.UnmapMember(c => c.User);
        });

        return serviceCollection;
    }
}
