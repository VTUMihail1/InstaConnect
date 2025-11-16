using InstaConnect.Common.Infrastructure;
using InstaConnect.Identity.Infrastructure.Abstractions;
using InstaConnect.Identity.Infrastructure.Utilities;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure;
public class IdentityContext : MongoDbContext, IIdentityContext
{
    public IdentityContext(IMongoClient mongoClient, IMongoDatabase mongoDatabase)
        : base(mongoClient, mongoDatabase)
    {
    }

    public IMongoCollection<User> Users => ToCollection<User>(IdentityCollectionNames.Users);

    public IMongoCollection<UserClaim> UserClaims => ToCollection<UserClaim>(IdentityCollectionNames.UserClaims);

    public IMongoCollection<RefreshToken> RefreshTokens => ToCollection<RefreshToken>(IdentityCollectionNames.RefreshTokens);

    public IMongoCollection<ForgotPasswordToken> ForgotPasswordTokens => ToCollection<ForgotPasswordToken>(IdentityCollectionNames.ForgotPasswordTokens);

    public IMongoCollection<EmailConfirmationToken> EmailConfirmationTokens => ToCollection<EmailConfirmationToken>(IdentityCollectionNames.EmailConfirmationTokens);
}
