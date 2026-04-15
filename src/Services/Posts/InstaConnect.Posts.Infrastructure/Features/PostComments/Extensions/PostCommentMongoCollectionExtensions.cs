using InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

internal static class PostCommentMongoCollectionExtensions
{
    extension(IMongoCollection<PostComment> collection)
    {
        public async Task UpdateAsync(
            IClientSessionHandle? session,
            PostComment entity,
            CancellationToken cancellationToken)
        {
            await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);
        }

        public async Task DeleteAsync(
            IClientSessionHandle? session,
            PostComment entity,
            CancellationToken cancellationToken)
        {
            await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
        }
    }
}
