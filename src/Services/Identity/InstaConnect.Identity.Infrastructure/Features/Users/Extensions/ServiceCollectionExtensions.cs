using InstaConnect.Identity.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserSortProperty>(IdentityInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IUserIncludeProperty>(IdentityInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<User>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.FirstName);
            cm.MapMember(c => c.LastName);
            cm.MapMember(c => c.Name);
            cm.MapMember(c => c.Email);
            cm.MapMember(c => c.PasswordHash);
            cm.MapMember(c => c.IsEmailConfirmed);
            cm.MapMember(c => c.ProfileImage);
            cm.MapMember(c => c.CreatedAtUtc);
            cm.MapMember(c => c.UpdatedAtUtc);

            cm.MapMember(c => c.Claims);
            cm.MapMember(c => c.RefreshTokens);
            cm.MapMember(c => c.ForgotPasswordTokens);
            cm.MapMember(c => c.EmailConfirmationTokens);

            cm.MapCreator(c => new User(
                new(c.Id.Id),
                c.FirstName,
                c.LastName,
                new(c.Email.Value),
                new(c.Name.Value),
                c.PasswordHash,
                c.IsEmailConfirmed,
                c.ProfileImage == null ? null : new(c.ProfileImage.Url),
                c.CreatedAtUtc,
                c.UpdatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
