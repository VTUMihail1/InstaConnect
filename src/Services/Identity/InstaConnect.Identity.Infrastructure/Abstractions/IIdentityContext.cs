using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Abstractions;

public interface IIdentityContext : IMongoDbContext
{
    public IMongoCollection<User> Users { get; }

    public IMongoCollection<UserClaim> UserClaims { get; }

    public IMongoCollection<RefreshToken> RefreshTokens { get; }

    public IMongoCollection<EmailConfirmationToken> EmailConfirmationTokens { get; }

    public IMongoCollection<ForgotPasswordToken> ForgotPasswordTokens { get; }
}
