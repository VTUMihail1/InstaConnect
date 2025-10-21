using InstaConnect.Common.Extensions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostCommentLikeServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostCommentLikeSortProperty>(PostInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IPostCommentLikeIncludeProperty>(PostInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<PostCommentLike>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => new { c.Id, c.CommentId, c.UserId })
              .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.UnmapMember(c => c.User);
        });

        return serviceCollection;
    }
}
