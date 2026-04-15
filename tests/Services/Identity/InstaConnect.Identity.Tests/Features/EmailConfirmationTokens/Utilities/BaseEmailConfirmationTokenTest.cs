using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Identity.Domain.Helpers;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenTest : BaseTest
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

    protected EmailConfirmationTokenBuilderFactory EmailConfirmationTokenBuilderFactory { get; }
    protected EmailConfirmationTokenBuilder EmailConfirmationTokenBuilder { get; }
    protected EmailConfirmationToken EmailConfirmationToken { get; }
    protected ICollection<EmailConfirmationToken> EmailConfirmationTokens { get; }

    protected CancellationToken CancellationToken { get; }

    protected BaseEmailConfirmationTokenTest(IPasswordHasher passwordHasher)
    {
        PasswordHasher = passwordHasher;
        Password = UserDataFaker.GetPassword();
        ProfileImage = UserDataFaker.GetProfileImage();

        UserBuilderFactory = new();
        UserBuilder = UserBuilderFactory.Create(PasswordHasher.Hash(Password), ProfileImage.GetUrl());
        User = UserBuilder.WithUnconfirmedEmail().Build();
        Users = User.Generate();

        UserClaimBuilderFactory = new();
        UserClaimBuilder = UserClaimBuilderFactory.Create(User);
        UserClaim = UserClaimBuilder.Build();
        UserClaims = UserClaim.Generate(Users);

        EmailConfirmationTokenBuilderFactory = new();
        EmailConfirmationTokenBuilder = EmailConfirmationTokenBuilderFactory.Create(User);
        EmailConfirmationToken = EmailConfirmationTokenBuilder.Build();
        EmailConfirmationTokens = EmailConfirmationToken.Generate(Users);

        CancellationToken = MockFactory.CreateCancellationToken();
    }
}
