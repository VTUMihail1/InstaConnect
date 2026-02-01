using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

internal static class UserMongoCollectionExtensions
{
    public static async Task UpdateAsync(
        this IMongoCollection<User> collection,
        IClientSessionHandle? session,
        User entity,
        CancellationToken cancellationToken)
    {
        await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);

    }

    public static async Task DeleteAsync(
        this IMongoCollection<User> collection,
        IClientSessionHandle? session,
        User entity,
        CancellationToken cancellationToken)
    {
        await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
    }
}
