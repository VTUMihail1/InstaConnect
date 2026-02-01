using InstaConnect.Posts.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserIncluder>(PostInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<User>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.FirstName);
            cm.MapMember(c => c.LastName);
            cm.MapMember(c => c.Name);
            cm.MapMember(c => c.Email);
            cm.MapMember(c => c.ProfileImage);
            cm.MapMember(c => c.CreatedAtUtc);
            cm.MapMember(c => c.UpdatedAtUtc);

            cm.MapMember(c => c.Posts);
            cm.MapMember(c => c.PostLikes);
            cm.MapMember(c => c.PostComments);
            cm.MapMember(c => c.PostCommentLikes);

            cm.MapCreator(c => new User(
                c.Id,
                c.FirstName,
                c.LastName,
                c.Email,
                c.Name,
                c.ProfileImage,
                c.CreatedAtUtc,
                c.UpdatedAtUtc));
        });

        return serviceCollection;
    }
}
