using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;
using InstaConnect.Identity.Domain.Helpers;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenTest : BaseTest
{
    protected IPasswordHasher PasswordHasher { get; }
    protected IAccessTokenGenerator AccessTokenGenerator { get; }
    protected string Password { get; }
    protected IFormFile ProfileImage { get; }
    protected AccessToken AccessToken { get; }

    protected UserBuilderFactory UserBuilderFactory { get; }
    protected UserBuilder UserBuilder { get; }
    protected User User { get; }
    protected ICollection<User> Users { get; }

    protected UserClaimBuilderFactory UserClaimBuilderFactory { get; }
    protected UserClaimBuilder UserClaimBuilder { get; }
    protected UserClaim UserClaim { get; }
    protected ICollection<UserClaim> UserClaims { get; }

    protected RefreshTokenBuilderFactory RefreshTokenBuilderFactory { get; }
    protected RefreshTokenBuilder RefreshTokenBuilder { get; }
    protected RefreshToken RefreshToken { get; }
    protected ICollection<RefreshToken> RefreshTokens { get; }

    protected CancellationToken CancellationToken { get; }

    protected BaseRefreshTokenTest(IPasswordHasher passwordHasher, IAccessTokenGenerator accessTokenGenerator)
    {
        PasswordHasher = passwordHasher;
        AccessTokenGenerator = accessTokenGenerator;
        Password = UserDataFaker.GetPassword();
        ProfileImage = UserDataFaker.GetProfileImage();

        UserBuilderFactory = new();
        UserBuilder = UserBuilderFactory.Create(PasswordHasher.Hash(Password), ProfileImage.GetUrl());
        User = UserBuilder.Build();
        Users = User.Generate();
        AccessToken = accessTokenGenerator.Generate(User);

        UserClaimBuilderFactory = new();
        UserClaimBuilder = UserClaimBuilderFactory.Create(User);
        UserClaim = UserClaimBuilder.Build();
        UserClaims = UserClaim.Generate(Users);

        RefreshTokenBuilderFactory = new();
        RefreshTokenBuilder = RefreshTokenBuilderFactory.Create(User);
        RefreshToken = RefreshTokenBuilder.Build();
        RefreshTokens = RefreshToken.Generate(Users);

        CancellationToken = MockFactory.CreateCancellationToken();
    }
}
