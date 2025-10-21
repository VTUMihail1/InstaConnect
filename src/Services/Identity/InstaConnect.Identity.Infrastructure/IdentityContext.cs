using InstaConnect.Common.Infrastructure;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Infrastructure.Abstractions;
using InstaConnect.Users.Infrastructure.Utilities;

using MongoDB.Driver;

namespace InstaConnect.Users.Infrastructure;
public class IdentityContext : MongoDbContext, IIdentityContext
{
    public IdentityContext(IMongoClient mongoClient, IMongoDatabase mongoDatabase)
        : base(mongoClient, mongoDatabase)
    {
    }

    public IMongoCollection<User> Users => Collection<User>(IdentityCollectionNames.Users);

    public IMongoCollection<UserClaim> UserClaims => Collection<UserClaim>(IdentityCollectionNames.UserClaims);

    public IMongoCollection<RefreshToken> RefreshTokens => Collection<RefreshToken>(IdentityCollectionNames.RefreshTokens);

    public IMongoCollection<ForgotPasswordToken> ForgotPasswordTokens => Collection<ForgotPasswordToken>(IdentityCollectionNames.ForgotPasswordTokens);

    public IMongoCollection<EmailConfirmationToken> EmailConfirmationTokens => Collection<EmailConfirmationToken>(IdentityCollectionNames.EmailConfirmationTokens);
}
