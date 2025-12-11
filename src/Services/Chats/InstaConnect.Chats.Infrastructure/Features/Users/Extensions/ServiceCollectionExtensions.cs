using InstaConnect.Chats.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserIncludeProperty>(ChatInfrastructureReference.Assembly);

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

            cm.MapMember(c => c.Chats);
            cm.MapMember(c => c.ChatMessages);

            cm.MapCreator(c => new User(
                c.Id,
                c.FirstName,
                c.LastName,
                c.Email,
                c.Name,
                c.ProfileImage,
                c.CreatedAtUtc,
                c.UpdatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
