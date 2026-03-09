namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public abstract class BaseUserTest : BaseTest
{
    protected UserBuilderFactory UserBuilderFactory { get; }
    protected UserBuilder UserBuilder { get; }
    protected User User { get; }
    protected ICollection<User> Users { get; }

    protected CancellationToken CancellationToken { get; }

    protected BaseUserTest()
    {
        UserBuilderFactory = new();
        UserBuilder = UserBuilderFactory.Create();
        User = UserBuilder.Build();
        Users = User.Generate();

        CancellationToken = MockFactory.CreateCancellationToken();
    }
}
