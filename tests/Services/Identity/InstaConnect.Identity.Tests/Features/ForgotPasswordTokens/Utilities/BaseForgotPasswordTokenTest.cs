using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenTest : BaseTest
{
    protected IPasswordHasher PasswordHasher { get; }
    protected string Password { get; }
    protected IFormFile ProfileImage { get; }

    protected UserBuilderFactory UserBuilderFactory { get; }
    protected UserBuilder UserBuilder { get; }
    protected User User { get; }
    protected ICollection<User> Users { get; }

    protected UserClaimBuilderFactory UserClaimBuilderFactory { get; }
    protected UserClaimBuilder UserClaimBuilder { get; }
    protected UserClaim UserClaim { get; }
    protected ICollection<UserClaim> UserClaims { get; }

    protected ForgotPasswordTokenBuilderFactory ForgotPasswordTokenBuilderFactory { get; }
    protected ForgotPasswordTokenBuilder ForgotPasswordTokenBuilder { get; }
    protected ForgotPasswordToken ForgotPasswordToken { get; }
    protected ICollection<ForgotPasswordToken> ForgotPasswordTokens { get; }

    protected CancellationToken CancellationToken { get; }

    protected BaseForgotPasswordTokenTest(IPasswordHasher passwordHasher)
    {
        PasswordHasher = passwordHasher;
        Password = UserDataFaker.GetPassword();
        ProfileImage = UserDataFaker.GetProfileImage();

        UserBuilderFactory = new();
        UserBuilder = UserBuilderFactory.Create(PasswordHasher.Hash(Password), ProfileImage.GetUrl());
        User = UserBuilder.Build();
        Users = User.Generate();

        UserClaimBuilderFactory = new();
        UserClaimBuilder = UserClaimBuilderFactory.Create(User);
        UserClaim = UserClaimBuilder.Build();
        UserClaims = UserClaim.Generate(Users);

        ForgotPasswordTokenBuilderFactory = new();
        ForgotPasswordTokenBuilder = ForgotPasswordTokenBuilderFactory.Create(User);
        ForgotPasswordToken = ForgotPasswordTokenBuilder.Build();
        ForgotPasswordTokens = ForgotPasswordToken.Generate(Users);

        CancellationToken = MockFactory.CreateCancellationToken();
    }
}
