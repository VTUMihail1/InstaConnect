using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenTest : BaseTest
{
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

    protected BaseRefreshTokenTest()
    {
        UserBuilderFactory = new();
        UserBuilder = UserBuilderFactory.Create();
        User = UserBuilder.Build();
        Users = User.Generate();

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
