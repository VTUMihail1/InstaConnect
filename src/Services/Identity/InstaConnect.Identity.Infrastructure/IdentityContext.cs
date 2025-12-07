using InstaConnect.Common.Infrastructure;
using InstaConnect.Identity.Infrastructure.Utilities;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure;
public class IdentityContext : MongoDbContext, IIdentityContext
{
    public IdentityContext(IMongoClient mongoClient, IMongoDatabase mongoDatabase)
        : base(mongoClient, mongoDatabase)
    {
    }

    public IMongoCollection<User> Users => ToCollection<User, UserId>(IdentityCollectionNames.Users);

    public IMongoCollection<UserClaim> UserClaims => ToCollection<UserClaim, UserClaimId>(IdentityCollectionNames.UserClaims);

    public IMongoCollection<RefreshToken> RefreshTokens => ToCollection<RefreshToken, RefreshTokenId>(IdentityCollectionNames.RefreshTokens);

    public IMongoCollection<ForgotPasswordToken> ForgotPasswordTokens => ToCollection<ForgotPasswordToken, ForgotPasswordTokenId>(IdentityCollectionNames.ForgotPasswordTokens);

    public IMongoCollection<EmailConfirmationToken> EmailConfirmationTokens => ToCollection<EmailConfirmationToken, EmailConfirmationTokenId>(IdentityCollectionNames.EmailConfirmationTokens);
}
