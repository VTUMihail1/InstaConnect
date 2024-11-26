using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Shared.Application.UnitTests.Utilities;

public class BaseSharedUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    public BaseSharedUnitTest(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IEntityPropertyValidator entityPropertyValidator)
    {
        UnitOfWork = unitOfWork;
        InstaConnectMapper = instaConnectMapper;
        CancellationToken = new CancellationToken();
        EntityPropertyValidator = entityPropertyValidator;
    }
}
