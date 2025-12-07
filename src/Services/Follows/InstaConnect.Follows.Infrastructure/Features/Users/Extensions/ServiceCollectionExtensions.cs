using InstaConnect.Follows.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserIncludeProperty>(FollowInfrastructureReference.Assembly);

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

            cm.MapMember(c => c.FollowerFollows);
            cm.MapMember(c => c.FollowingFollows);

            cm.MapCreator(c => new User(
                new(c.Id.Id),
                c.FirstName,
                c.LastName,
                new(c.Email.Value),
                new(c.Name.Value),
                c.ProfileImage == null ? null : new(c.ProfileImage.Url),
                c.CreatedAtUtc,
                c.UpdatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
