using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using MongoDB.Driver;

namespace InstaConnect.Users.Infrastructure.Abstractions;
public interface IIdentityContext : IMongoDbContext
{
    public IMongoCollection<User> Users { get; }

    public IMongoCollection<UserClaim> UserClaims { get; }

    public IMongoCollection<RefreshToken> RefreshTokens { get; }

    public IMongoCollection<EmailConfirmationToken> EmailConfirmationTokens { get; }

    public IMongoCollection<ForgotPasswordToken> ForgotPasswordTokens { get; }
}
