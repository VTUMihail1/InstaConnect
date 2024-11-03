using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Abstractions;

namespace InstaConnect.Shared.Web.UnitTests.Utilities;

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
