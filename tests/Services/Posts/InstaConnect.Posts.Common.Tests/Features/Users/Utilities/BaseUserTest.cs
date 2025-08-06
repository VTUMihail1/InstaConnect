using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.AddApiRequest;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities;
public abstract class BaseUserTest
{
    protected UserBuilderFactory UserBuilderFactory { get; }
    protected UserBuilder UserBuilder { get; }
    protected User User { get; }

    protected CancellationToken CancellationToken { get; }

    protected BaseUserTest()
    {
        UserBuilderFactory = new();
        UserBuilder = UserBuilderFactory.Create();
        User = UserBuilder.Create();

        CancellationToken = MockFactory.CreateCancellationToken();
    }
}
