using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Presentation.Abstractions;

namespace InstaConnect.Shared.Presentation.UnitTests.Utilities;

public class BaseSharedUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected ICurrentUserContext CurrentUserContext { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    public BaseSharedUnitTest(
        IInstaConnectSender instaConnectSender,
        ICurrentUserContext currentUserContext,
        IInstaConnectMapper instaConnectMapper)
    {
        CancellationToken = new CancellationToken();
        InstaConnectSender = instaConnectSender;
        CurrentUserContext = currentUserContext;
        InstaConnectMapper = instaConnectMapper;
    }
}
